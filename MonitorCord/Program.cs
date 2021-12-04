using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace MonitorCord
{
    class Program
    {

        public static void Main(string[] args)
        {

            Server server = new Server("Test-Server", "127.0.0.1", "");

            server.Messagesenderprofilpictureconfig = "https://avatars.githubusercontent.com/u/65872875?v=4";
            server.Messagesendernameconfig = "Monitoring Test";
            server.Servernameconfig = "Server";
            server.Serverstatusconfig = "Status";

            server.PingServer();





            //Console.Write("Wer soll gepingt werden: ");
            //string ip = Console.ReadLine();
            //Console.Write("Gebe bitte einen Anzeige namen an: ");
            //string showofname = Console.ReadLine();

            //int debug = 0;
            //int[] latest = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

            //Random random = new Random();
            //Pinger pingCatcher = new Pinger(ip,showofname);


            //while (true)
            //{
            //    bool NumberAccepted = false;
            //    pingCatcher.pinger();
            //    while(NumberAccepted == false)
            //    {
            //        debug = random.Next(11, 30) * 1000;

            //        bool[] acceptlist = new bool[8];

            //        for (int i = 0; i < latest.Length; i++)
            //        {
            //            if (debug == latest[i])
            //            {
            //                acceptlist[i] = true;
            //            }
            //            else if(debug != latest[i])
            //            {
            //                acceptlist[i] = false;
            //            }
            //        }

            //        if (acceptlist[0] == false && acceptlist[1] == false && acceptlist[2] == false && acceptlist[3] == false && acceptlist[4] == false && acceptlist[5] == false && acceptlist[6] == false && acceptlist[7] == false)
            //        {
            //            NumberAccepted = true;
            //        }

            //        if (NumberAccepted == true)
            //        {
            //            for (int i_1 = latest.Length - 1; i_1 != 0; i_1--)
            //            {
            //                latest[i_1] = latest[i_1 - 1];
            //            }
            //            latest[0] = debug;
            //        }
            //    }
            //    //Console.WriteLine(debug);
            //    Thread.Sleep(debug);
            //}
        }
    }
}
