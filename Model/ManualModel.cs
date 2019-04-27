using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.ViewModels;
namespace FlightSimulator.Model
{
    /*
     * class ManualModel
     * responsible on the logic of manual 
     */
    class ManualModel : BaseNotify
    {
        private double rudder;
        private string rudderVal;
        private double throttle;
        private string throttleVal;
        private double aileron;
        private string aileronVal;
        private double elevator;
        private string elevatorVal;

        private Sender sender;

        public ManualModel()
        {
            // get the instans of the client that can send msg to the simulator
            sender = Singleton.Instance;
        }
        // property
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = value;
                ElevatorVal = Math.Round(value, 2).ToString();
                NotifyPropertyChanged("Elevator");
                SendElevator(value);
            }
        }
        // property to show the elevator value
        public string ElevatorVal
        {
            get
            {
                return elevatorVal;
            }
            set
            {
                elevatorVal = value;
                NotifyPropertyChanged("ElevatorVal");
            }
        }
        // property
        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                AileronVal = Math.Round(value, 2).ToString();
                NotifyPropertyChanged("Aileron");
                SendAileron(value);
            }
        }
        // property
        public string AileronVal
        {
            get
            {
                return aileronVal;
            }
            set
            {
                aileronVal = value;
                NotifyPropertyChanged("AileronVal");
            }
        }
        // property
        public double Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;
                RudderVal = Math.Round(value, 2).ToString();
                NotifyPropertyChanged("Rudder");
                SendRudder(value);
            }
        }
        // property
        public string RudderVal
        {
            get
            {
                return rudderVal;
            }
            set
            {
                rudderVal = value;
                NotifyPropertyChanged("RudderVal");
            }
        }
        // send to the relavant path
        void SendRudder(double val)
        {
            string msg = "set controls/flight/rudder " + Math.Round(val, 2).ToString() + "\r\n";
            sender.Send(msg);
        }
        // property
        public double Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                ThrottleVal = Math.Round(value, 2).ToString();
                NotifyPropertyChanged("Throttle");
                SendThrottle(value);
            }
        }
        // property
        public string ThrottleVal
        {
            get
            {
                return throttleVal;
            }
            set
            {
                throttleVal = value;
                NotifyPropertyChanged("ThrottleVal");
            }
        }

        // send to the relavant path
        void SendThrottle(double val)
        {
            string msg = "set controls/engines/current-engine/throttle " + Math.Round(val, 2).ToString() + "\r\n";
            sender.Send(msg);
        }

        // send to the relavant path
        void SendAileron(double val)
        {
            string msg = "set controls/flight/aileron " + Math.Round(val, 2).ToString() + "\r\n";
            sender.Send(msg);
        }

        // send to the relavant path
        void SendElevator(double val)
        {
            string msg = "set controls/flight/elevator " + Math.Round(val, 2).ToString() + "\r\n";
            sender.Send(msg);
        }

    }
}
