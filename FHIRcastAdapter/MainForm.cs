using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using WebSocketSharp;
using System.IO;

namespace FHIRcastAdapter
{
    public partial class MainForm : Form
    {
   
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            string statusCode=subscribe(hubURL.Text);
        }

        static String subscribe(string url)
        {
            String hub_callback = "na";
            String hub_mode = "subscribe";
            String hub_events = "open-patient-chart";
            String hub_secret = "secret";
            String hub_topic = "DrXRay";
            String hub_lease = "999";
            String hub_channel_type = "websocket";
            String hub_channel_endpoint = "endpointUID";

            String result = "";
            String strPost = "hub.callback=" + hub_callback + "&hub.mode=" + hub_mode + "&hub.events=" + hub_events;
            strPost = strPost + "&hub.secret=" + hub_secret + "&hub.topic=" + hub_topic + "&hub.lease=" + hub_lease;
            strPost = strPost + "&hub.channel.type=" + hub_channel_type + "&hub.channel.endpoint=" + hub_channel_endpoint;

            StreamWriter myWriter = null;

            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            objRequest.ContentLength = strPost.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

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
            using (StreamReader sr =
               new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();

                // Close and clean up the StreamReader
                sr.Close();
            }

            string uriSocket = "ws://localhost:3000/bind/endpointUID";
            var ws = new WebSocket(uriSocket);
            ws.Connect();

            return result;
        }
   
    }
}
