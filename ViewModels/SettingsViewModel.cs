using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System.Windows.Input;
using FlightSimulator.Views.Windows;

namespace FlightSimulator.ViewModels

{
    class SettingsViewModel : BaseNotify
    {
        private ISettingsModel model;
        private ICommand _okCommand;
        private ICommand _cancelCommand;
        private Settings settings;
        

        public SettingsViewModel(Settings s)
        {
            model = ApplicationSettingsModel.Instance;
            VM_FlightServerIP = model.FlightServerIP;
            VM_FlightInfoPort = model.FlightInfoPort;
            VM_FlightCommandPort = model.FlightCommandPort;
            this.settings = s;
        }

        public string VM_FlightServerIP
        {
            get
            {
                return model.FlightServerIP;
            }
            set
            {
                model.FlightServerIP = value;
                NotifyPropertyChanged("VM_FlightServerIP");
            }
        }

        public int VM_FlightCommandPort
        {
            get
            {
                return model.FlightCommandPort;
            }
            set
            {
                model.FlightCommandPort = value;
                NotifyPropertyChanged("VM_FlightCommandPort");
            }
        }

        public int VM_FlightInfoPort
        {
            get
            {
                return model.FlightInfoPort;
            }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("VM_FlightInfoPort");
            }
        }

        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => ClickOk()));
            }
        }

        private void ClickOk()
        {
            model.SaveSettings();
            settings.Close();
            
        }

        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => ClickCancel()));
            }
        }

        private void ClickCancel()
        {
            model.ReloadSettings();
            settings.Close();
        }
    }
}
