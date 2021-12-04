using Discord.Webhook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonitorCord
{
    class PingCatcher
    {
        private Server server;
        private bool statusIsOnline;

        public PingCatcher(Server server)
        {
            this.server = server;
        }

        public bool PingSuccses()
        {
            if (server.Address.Length == 0)
            {
                throw new ArgumentException("Ping needs a host or IP Address.");
            }

            string who = server.Address;
            AutoResetEvent waiter = new AutoResetEvent(false);

            Ping pingSender = new Ping();

            // When the PingCompleted event is raised,
            // the PingCompletedCallback method is called.
            pingSender.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            // Wait 12 seconds for a reply.
            int timeout = 12000;

            // Set options for transmission:
            // The data can go through 64 gateways or routers
            // before it is destroyed, and the data packet
            // cannot be fragmented.
            PingOptions options = new PingOptions(64, true);


            // Send the ping asynchronously.
            // Use the waiter as the user token.
            // When the callback completes, it can wake up this thread.
            pingSender.SendAsync(who, timeout, buffer, options, waiter);

            waiter.WaitOne();

            return statusIsOnline;
        }
        private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {



            PingReply reply = e.Reply;

            DisplayReply(reply);

            // Let the main thread resume.
            ((AutoResetEvent)e.UserState).Set();
        }
        public void DisplayReply(PingReply reply)
        {
            if (reply.Status == IPStatus.Success)
            {
                if (reply.Status == IPStatus.Success)
                {
                    if (statusIsOnline == false)
                    {
                        statusIsOnline = true;
                    }
                }
                else
                {
                    if (statusIsOnline == true)
                    {
                        statusIsOnline = false;
                    }
                }
            }
        }
    }
}
