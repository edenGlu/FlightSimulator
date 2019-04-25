using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;


namespace FlightSimulator.ViewModels
{
    class ManualViewModel : BaseNotify
    {
        
        private ManualModel model;

        public ManualViewModel()
        {
            model = new ManualModel(); // create the model
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        // proprty
        public double VM_Rudder {
            get
            {
                return model.Rudder;
            }
            set
            {
                model.Rudder = value;
            }
        }
        // proprty
        public string VM_RudderVal
        {
            get
            {
                return model.RudderVal;
            }
            set
            {
                NotifyPropertyChanged("VM_RudderVal");
            }
        }
        // proprty
        public double VM_Throttle
        {
            get
            {
                return model.Throttle;
            }
            set
            {
                model.Throttle = value;
            }
        }
        // proprty
        public string VM_ThrottleVal
        {
            get
            {
                return model.ThrottleVal;
            }
            set
            {
                NotifyPropertyChanged("VM_ThrottleVal");
            }
        }
        // proprty
        public double VM_Elevator
        {
            get
            {
                return model.Elevator;
            }
            set
            {
                model.Elevator = value;
            }
        }
        // proprty
        public string VM_ElevatorVal
        {
            get
            {
                return model.ElevatorVal;
            }
            set
            {
                NotifyPropertyChanged("VM_ElevatorVal");
            }
        }
        // proprty
        public double VM_Aileron
        {
            get
            {
                return model.Aileron;
            }
            set
            {
                model.Aileron = value;
            }
        }
        // proprty
        public string VM_AileronVal
        {
            get
            {
                return model.AileronVal;
            }
            set
            {
                NotifyPropertyChanged("VM_AileronVal");
            }
        }



    }
}
