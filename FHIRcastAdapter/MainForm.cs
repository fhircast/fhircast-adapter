using System;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Management.Automation.Runspaces;
using WebSocketSharp;

namespace FHIRcastAdapter
{
    public partial class MainForm : Form
    {
        public static WebSocket ws;
        public static string windowsUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public static string hostname = System.Environment.MachineName;
        public static string currentDirectory  = Directory.GetCurrentDirectory();

        public MainForm()
        {
            InitializeComponent();
            log("FHIRcast Adapter starting on host " + hostname + ", user: " + windowsUser);
            hubURL.Text = FHIRcastAdapter.Properties.Settings.Default.hubURL;
            secret.Text= FHIRcastAdapter.Properties.Settings.Default.secret;
            string watchDirectory = currentDirectory + "\\req\\";
            DirectoryInfo di = Directory.CreateDirectory(watchDirectory);
            foreach (FileInfo file in di.GetFiles()) { file.Delete(); }
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = watchDirectory;
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.Created += new FileSystemEventHandler(fileDropped);
            watcher.EnableRaisingEvents = true;
            log("Watching directory " + watchDirectory);
        }

        public void log(string logText)
        {
            logList.Items.Add(logText);
        }

        private void fileDropped(object source, FileSystemEventArgs e)
        {
            log("Found file: " + e.FullPath);
            string fileContent;
            using (var streamReader = new StreamReader(e.FullPath)) {fileContent = streamReader.ReadToEnd();}
            if (e.Name.EndsWith(".json"))  { notify(hubURL.Text, fileContent); }
            else
            {
                try
                {
                    string scriptText;
                    using (var streamReader = new StreamReader("./receive.ps1.txt"))
                    {
                        scriptText = streamReader.ReadToEnd();
                    }
                    Runspace runspace = RunspaceFactory.CreateRunspace();
                    runspace.ApartmentState = System.Threading.ApartmentState.STA;
                    runspace.Open();
                    runspace.SessionStateProxy.SetVariable("filepath", e.FullPath);
                    runspace.SessionStateProxy.SetVariable("user", windowsUser);
                    runspace.SessionStateProxy.SetVariable("currentDirectory", currentDirectory);
                    runspace.SessionStateProxy.SetVariable("hostname", hostname);
      //              Pipeline pipeline = runspace.CreatePipeline();
      //              pipeline.Commands.AddScript(scriptText);
         //          log("Starting script " + PSFilename);
        //            Collection<PSObject> results = pipeline.Invoke();                  
         //           log("Finished script " + PSFilename);
                    //        if (results[0].ToString().Length>0) { log("Script result is:" + results[0].ToString()); }
       //             pipeline.Dispose();
                    runspace.Close();
                    runspace.Dispose();
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

        private String subscribe(string url)
        {
            String hub_callback = "na";
            String hub_mode = "subscribe";
            String hub_secret = secret.Text;
            String hub_topic = "DrXRay";
            String hub_lease = "999";
            String hub_channel_type = "websocket";
            String hub_channel_endpoint = "endpointUID";
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
            webSocketURL += "://"+urlParts[2]+"/bind/endpointUID";
            log("Binding websocket: " + webSocketURL);
            ws = new WebSocket(webSocketURL);
            ws.Connect();
  //          if (ws.ReadyState != WebSocketState.Open)
  //          {
  //              log("WebSocket is not open.  Request a subscription first.");
  //          }
            return result;
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

        private void btnSubscribe_Click(object sender, EventArgs e) { string statusCode = subscribe(hubURL.Text); }
        private void btnShutdown_Click(object sender, EventArgs e) { Application.Exit(); }
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e) { this.Show();}

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
