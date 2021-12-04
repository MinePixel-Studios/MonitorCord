using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorCord
{
    class Server
    {
        private string name;
        private string address;
        private string webhook;
        private string status;
        private string servernameconfig;
        private string serverstatusconfig;
        private string messagesendernameconfig;
        private string messagesenderprofilpictureconfig;


        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Webhook { get => webhook; set => webhook = value; }
        public string Status { get => status; set => status = value; }
        public string Servernameconfig { get => servernameconfig; set => servernameconfig = value; }
        public string Serverstatusconfig { get => serverstatusconfig; set => serverstatusconfig = value; }
        public string Messagesendernameconfig { get => messagesendernameconfig; set => messagesendernameconfig = value; }
        public string Messagesenderprofilpictureconfig { get => messagesenderprofilpictureconfig; set => messagesenderprofilpictureconfig = value; }

        public Server(string servername, string address, string webhook)
        {
            this.name = servername;
            this.address = address;
            this.webhook = webhook;
            this.Status = "DOWN";
        }
        public Server(string servername, string address, string webhook, string status)
        {
            this.name = servername;
            this.address = address;
            this.webhook = webhook;
            this.status = status;
        }

        public void SaveServer()
        {

        }
        public void PingServer()
        {
            PingCatcher pingCatcher = new PingCatcher(this);
            
            if(pingCatcher.PingSuccses() == true && status == "DOWN")
            {
                status = "UP";
                SendStatus();
            }
            if (pingCatcher.PingSuccses() == false && status == "UP")
            {
                status = "DOWN";
                SendStatus();
            }
        }
        public void GetSettings()
        {

        }
        public void SendStatus()
        {
            MessageHandler messageHandler = new MessageHandler();
            messageHandler.MessageSenderAsync(this);
        }
    }
}
