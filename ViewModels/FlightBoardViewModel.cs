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
    // class FlightBoardViewModel
    public class FlightBoardViewModel : BaseNotify
    {
        private Server server;
        // constractor
        public FlightBoardViewModel()
        {
            // get instans of the server
            server = IServer.Instance;
            server.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
        }
        // proprty Lon
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
        // proprty Lan
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
