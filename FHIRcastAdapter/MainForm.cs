using System;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using WebSocket4Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FHIRcastAdapter
{
    public partial class MainForm : Form
    {
        private WebSocket ws;
        private string windowsUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        private string hostname = System.Environment.MachineName;
        private static string currentDirectory  = Directory.GetCurrentDirectory();
        private string watchDirectory = currentDirectory + "\\req\\";
        private string receiveDirectory = currentDirectory + "\\rcv\\";
        public static IntelliSpaceForm iSiteControl;
        public static string canvasPageID;


        public MainForm()
        {
            InitializeComponent();
            log("FHIRcast Adapter starting on host " + hostname + ", user: " + windowsUser);
            hubURL.Text = FHIRcastAdapter.Properties.Settings.Default.hubURL;
            secret.Text= FHIRcastAdapter.Properties.Settings.Default.secret;
            topic.Text = Guid.NewGuid().ToString().Substring(10);
            autoSubscribe.Checked=Properties.Settings.Default.autoSubscribe  ;
            iSite.Checked=Properties.Settings.Default.iSite ;
            iSiteHostname.Text = Properties.Settings.Default.iSiteHost;
            if (!string.IsNullOrEmpty(Properties.Settings.Default.events))
            {
                string[] checkedIndicies = Properties.Settings.Default.events.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i1 = 0; i1 < checkedIndicies.Length; i1++)
                {
                    int idx;
                    if ((int.TryParse(checkedIndicies[i1], out idx)) && (events.Items.Count >= (idx + 1)))
                    {
                        events.SetItemChecked(idx, true);
                    }
                }
            }

            string[] directories = { watchDirectory, receiveDirectory };
            foreach (string dir in directories)
            {
                DirectoryInfo di = Directory.CreateDirectory(dir);
                foreach (FileInfo file in di.GetFiles()) { file.Delete(); }
            }

            FileSystemWatcher watcher = new FileSystemWatcher
            {
                Path = watchDirectory,
                NotifyFilter = NotifyFilters.FileName
            };
            watcher.Created += new FileSystemEventHandler(fileDropped);
            watcher.EnableRaisingEvents = true;
            log("Watching directory " + watchDirectory);

            if (autoSubscribe.Checked) { string statusCode = subscribe("subscribe", hubURL.Text); }

            if (iSite.Checked && iSiteHostname.Text!="")
            {
                log("Starting Philips iSite control with host: " + iSiteHostname.Text);
                iSiteControl = new IntelliSpaceForm();
                iSiteControl.init(iSiteHostname.Text);
                iSiteControl.Show();
                iSiteControl.Visible = true;
            }
        }

        public void log(string logText)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    logList.Items.Add(logText);
                });
            }
            else { logList.Items.Add(logText); }
        }

        private void fileDropped(object source, FileSystemEventArgs e)
        {
            log("Found file: " + e.FullPath);
            string fileContent = File.ReadAllText(e.FullPath);
            if (e.Name.EndsWith(".json"))  { notify(hubURL.Text, fileContent); }
            else
            {
                try
                {
                    string script = File.ReadAllText(currentDirectory + "\\publish.ps1.txt");
                    Runspace runspace = RunspaceFactory.CreateRunspace();
                    runspace.ApartmentState = System.Threading.ApartmentState.STA;
                    runspace.Open();
                    runspace.SessionStateProxy.SetVariable("user", windowsUser);
                    runspace.SessionStateProxy.SetVariable("currentDirectory", currentDirectory);
                    runspace.SessionStateProxy.SetVariable("hostname", hostname);
                    runspace.SessionStateProxy.SetVariable("topic", topic.Text);
                    runspace.SessionStateProxy.SetVariable("fileContent",fileContent);
                    Pipeline pipeline = runspace.CreatePipeline();
                    pipeline.Commands.AddScript(script);
                    log("Starting handler script.");
                    Collection<PSObject> results = pipeline.Invoke();
                    log("Finished script.");
                    pipeline.Dispose();
                    runspace.Close();
                    runspace.Dispose();

                    if (results[0].ToString().Length > 0)
                    {
                        log("Script result is:" + results[0].ToString());
                        ws.Send(results[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    log("Exception raised calling Powershell. \n");
                    log(ex.Message + "\n");
                    if (ex.InnerException != null) { log(ex.InnerException + "\n"); }
                    if (ex.Data != null) { log(ex.Data + "\n"); }
                }
            }
            File.Delete(e.FullPath);
        }

        private void notify(string url, string msg)
        {
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            objRequest.ContentLength = msg.Length;
            objRequest.ContentType = "application/json";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(msg);
            }
            catch (Exception e)
            {
                log(e.Message);
            }
            finally
            {
                myWriter.Close();
            }
        }

        private String subscribe(string hub_mode, string url)
        {
            String hub_callback = "na";
            String hub_secret = secret.Text;
            String hub_topic = topic.Text;
            String hub_lease = "999";
            String hub_channel_type = "websocket";
            String hub_channel_endpoint = topic.Text;
            String hub_events = "";
            foreach (var item in events.CheckedItems) { hub_events += item.ToString()+",";}
            hub_events=hub_events.TrimEnd(',');
            String result = "";
            String strPost = "hub.callback=" + hub_callback + "&hub.mode=" + hub_mode + "&hub.events=" + hub_events;
            strPost = strPost + "&hub.secret=" + hub_secret + "&hub.topic=" + hub_topic + "&hub.lease=" + hub_lease;
            strPost = strPost + "&hub.channel.type=" + hub_channel_type + "&hub.channel.endpoint=" + hub_channel_endpoint;
            log("Posting subscription request to " + url);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            objRequest.ContentLength = strPost.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";
            StreamWriter myWriter = null;
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(strPost);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                log("Subscription result: " + result);
                sr.Close();
            }

            string[] urlParts= url.Split('/');
            string webSocketURL = "ws";
            if (urlParts[0]=="https") { webSocketURL += "s"; }
            webSocketURL += "://"+urlParts[2]+"/bind/"+hub_topic;
            log("Binding websocket: " + webSocketURL);

            ws = new WebSocket(webSocketURL);
            ws.MessageReceived += ws_MessageReceived;
            ws.Open();
 
            return result;
        }

        public class identifiers
        {
            [JsonProperty(PropertyName = "system")]
            public string system { get; set; }
            [JsonProperty(PropertyName = "value")]
            public string value { get; set; }
        }
        public class resources
        {
            [JsonProperty(PropertyName = "resourceType")]
            public string resourceType { get; set; }
            [JsonProperty(PropertyName = "id")]
            public string id { get; set; }
            [JsonProperty(PropertyName = "uid")]
            public string uid { get; set; }

            public List<identifiers> identifier { get; set; }
        }

        public class context
        {
            [JsonProperty(PropertyName = "key")]
            public string key { get; set; }
            [JsonProperty(PropertyName = "resource")]
            public resources resource { get; set; }
        }

        public class eventDef
        {
            [JsonProperty(PropertyName = "hub.topic")]
            public string hub_topic { get; set; }
            [JsonProperty(PropertyName = "hub.event")]
            public string hub_event { get; set; }
            public List<context> context { get; set; }
        }
        public class FHIRcastEvent
        {
            [JsonProperty(PropertyName = "timestamp")]
            public string timestamp { get; set; }
            [JsonProperty(PropertyName = "id")]
            public string id { get; set; }
            [JsonProperty(PropertyName = "event")]
            public eventDef eventDef { get; set; }
        }

        private void ws_MessageReceived(object sender, MessageReceivedEventArgs e)
        {

            if (e.Message.ToString().Contains("bound")) { 
                log("Received acknowledge from the hub.");
            }
            else
            {
                log("Received event from the hub: " + e.Message.ToString());
                if (iSite.Checked)
                {
                    string patientID = "";
                    string  accNbr="";
                    dynamic eventJSON = JsonConvert.DeserializeObject<FHIRcastEvent>(e.Message.ToString()); // JValue.Parse(e.Message.ToString());
                    string eventName = eventJSON.eventDef.hub_event;
                    if (eventName != "logout-user")
                    {
                        foreach (var contextEntry in eventJSON.eventDef.context)
                        {
                            if (contextEntry.resource.resourceType == "Patient")
                            {
                                patientID = contextEntry.resource.identifier[0].value;
                            }
                            if (contextEntry.resource.resourceType == "ImagingStudy")
                            {
                                accNbr = contextEntry.resource.identifier[0].value;
                            }
                        }
                        if (eventName == "open-imaging-study")
                        {
                            canvasPageID = iSiteControl.loadExam(patientID, accNbr, "DEFAULT");
                        }
                        else { iSiteControl.closeExam(canvasPageID); }
                    }
                    else { iSiteControl.logout(); }
                }
                else
                { 
                    if (File.Exists(currentDirectory + "\\receive.ps1.txt"))
                    {
                        string script = File.ReadAllText(currentDirectory + "\\receive.ps1.txt");
                        Runspace runspace = RunspaceFactory.CreateRunspace();
                        runspace.ApartmentState = System.Threading.ApartmentState.STA;
                        runspace.Open();
                        runspace.SessionStateProxy.SetVariable("user", windowsUser);
                        runspace.SessionStateProxy.SetVariable("currentDirectory", currentDirectory);
                        runspace.SessionStateProxy.SetVariable("hostname", hostname);
                        runspace.SessionStateProxy.SetVariable("event", e.Message.ToString());
                        Pipeline pipeline = runspace.CreatePipeline();
                        pipeline.Commands.AddScript(script);
                        log("Starting handler script.");
                        Collection<PSObject> results = pipeline.Invoke();                  
                        log("Finished script.");
                        if (results[0].ToString().Length>0) { log("Script result is:" + results[0].ToString()); }
                        pipeline.Dispose();
                        runspace.Close();
                        runspace.Dispose();
                    }
                    else
                    {
                        log("No handler script found.  Saving to file. ");
                        System.IO.File.WriteAllText(receiveDirectory + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".json", e.Message.ToString());
                    }
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown ||
                e.CloseReason == CloseReason.ApplicationExitCall ||
                e.CloseReason == CloseReason.TaskManagerClosing)
            { return; }
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            base.OnFormClosing(e);
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            string statusCode = subscribe("subscribe",hubURL.Text);
        }
        
        private void btnUnSubscribe_Click(object sender, EventArgs e)
        {
            string statusCode = subscribe("unsubscribe", hubURL.Text);
        }

        private void btnShutdown_Click(object sender, EventArgs e) { Application.Exit(); }
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e) { this.Show(); }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/fhircast/fhircast-adapter");
        }

        private void btnDeleteSubscriptions_Click(object sender, EventArgs e)
        {
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(hubURL.Text);
            objRequest.Method = "DELETE";

            StreamWriter myWriter = null;
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write("");
            }
            catch (Exception ex)
            {
               log(ex.Message);
            }
            finally
            {
                myWriter.Close();
            }
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                string result = sr.ReadToEnd();
                log("Delete subscription result: " + result);
                sr.Close();
            }

        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            //ws.Send("hello");
            Properties.Settings.Default.hubURL=hubURL.Text ;
            Properties.Settings.Default.secret = secret.Text ;
            Properties.Settings.Default.autoSubscribe = autoSubscribe.Checked;
            Properties.Settings.Default.iSite = iSite.Checked;
            Properties.Settings.Default.iSiteHost = iSiteHostname.Text;

            string idx = string.Empty;
            for (int i1 = 0; i1 < events.CheckedIndices.Count; i1++)
                idx += (string.IsNullOrEmpty(idx) ? string.Empty : ",") + Convert.ToString(events.CheckedIndices[i1]);
            Properties.Settings.Default.events = idx;


            Properties.Settings.Default.Save();
        }
    }
}
