using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightSimulator.ViewModels;
namespace FlightSimulator.Model
{
    //  class Server
    // get the data from the simulator 
    class Server : BaseNotify
    {
        private TcpListener listener = null;
        private TcpClient client = null;
        private bool sholdStop = false;
        private float lat;
        private float lon;
        private bool update = false;

       // proprty that resposible to notify about change
        public float Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
              
        }

        // proprty that resposible to notify about change
        public float Lon
        {
            get
            {
                return lon;
            }
            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }

        }
        // open a socket with the ip and port and whit for client
        public void Connect(string IP, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);
            listener = new TcpListener(ep);
            listener.Start(); // the server socket
            client = listener.AcceptTcpClient(); // whit for client
            Thread thread = new Thread(this.ReadFromClient); 
            // open new thread For communication with the customer
            thread.Start();
        }
        // whit for msg from the client
        public void ReadFromClient()
        {
            using (NetworkStream stream = client.GetStream())           
            {
                // whit until change the sholdStop memmber
                while (!sholdStop)
                {
                    Byte[] values = new Byte[client.ReceiveBufferSize];
                    int x = stream.Read(values, 0, values.Length); // get the data
                    string[] data = Encoding.ASCII.GetString(values, 0, x).Split(',');
                    if (float.Parse(data[21], CultureInfo.InvariantCulture.NumberFormat) > 0 && !update)
                        // if it is the first time that the plane start to move 
                        // the trutel value is in place 21
                    {
                        // Initializing the initial position
                        lat = float.Parse(data[0], CultureInfo.InvariantCulture.NumberFormat);
                        lon = float.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat);
                        update = true;
                    }
                    // update all and notify 
                    if (update)
                    {
                        Lat = float.Parse(data[0], CultureInfo.InvariantCulture.NumberFormat);
                        Lon = float.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat);
                    }
                }
            }
        }
        // close the client and than the server if they open
        public void CloseServer()
        {
            this.sholdStop = true; // Stops receiving messages
            Thread.Sleep(1000);
            if (client != null)
            {
                client.Close();
            }
            if (listener != null)
            {
                listener.Stop();
            }
        }
    }
}
