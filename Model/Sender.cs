using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class Sender 
    {
        private TcpClient client = null;
        NetworkStream stream;
        BinaryWriter writer;

        public void Connect(int port, string ip)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new TcpClient();
            client.Connect(ep);
            stream = client.GetStream();
            writer = new BinaryWriter(stream);
        }

        public void Send(string msg)
        {
            byte[] b = Encoding.ASCII.GetBytes(msg);
            stream.Write(b, 0, b.Length);
        }

        public void CLoseClient()
        {
            if (client != null)
            {
                client.Close();
            }
        }
    }
}
