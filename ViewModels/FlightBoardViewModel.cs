using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private Server server;

        public FlightBoardViewModel()
        {
            server = IServer.Instance;
            server.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
        }

        public double Lon
        {
            get
            {
                return server.Lon;
            }
            set
            {
                NotifyPropertyChanged("Lon");
            }
        }

        public double Lat
        {
            get
            {
                return server.Lat;
            }
            set
            {
                NotifyPropertyChanged("Lat");
            }
        }
    }
}
