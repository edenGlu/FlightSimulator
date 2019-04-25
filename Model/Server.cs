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
    class Server : BaseNotify
    {
        private TcpListener listener = null;
        private TcpClient client = null;
        private bool sholdStop = false;
        private float lat;
        private float lon;
        private bool update = false;

        public Server()
        {    
        }

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

        public void Connect(string IP, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);
            listener = new TcpListener(ep);
            listener.Start();
            client = listener.AcceptTcpClient();
            Thread thread = new Thread(this.ReadFromClient);
            thread.Start();
        }

        public void ReadFromClient()
        {
            using (NetworkStream stream = client.GetStream())           
            {
                while (!sholdStop)
                {
                    Byte[] values = new Byte[client.ReceiveBufferSize];
                    int x = stream.Read(values, 0, values.Length);
                    string[] data = Encoding.ASCII.GetString(values, 0, x).Split(',');
                    if (float.Parse(data[21], CultureInfo.InvariantCulture.NumberFormat) > 0)
                    {
                        lat = float.Parse(data[0], CultureInfo.InvariantCulture.NumberFormat);
                        lon = float.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat);
                        update = true;
                    }
                    if (update)
                    {
                        Lat = float.Parse(data[0], CultureInfo.InvariantCulture.NumberFormat);
                        Lon = float.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat);
                    }
                }
            }
        }

        public void CloseServer()
        {
            this.sholdStop = true;
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
