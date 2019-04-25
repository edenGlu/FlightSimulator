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
        
        // get the setting viwe 
        public SettingsViewModel(Settings s)
        {
           
            model = ApplicationSettingsModel.Instance; // get the instance of the modle
            // initializ the proprtys
            VM_FlightServerIP = model.FlightServerIP;
            VM_FlightInfoPort = model.FlightInfoPort;
            VM_FlightCommandPort = model.FlightCommandPort;
            this.settings = s;
        }
        // proprty
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
        // proprty
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
        // proprty
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
        // the command of the ok buttom
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => ClickOk()));
            }
        }
        // the logic of the ok buttom 
        private void ClickOk()
        {
            model.SaveSettings();
            settings.Close();
            
        }
        // the Command of the cancel buttom 
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => ClickCancel()));
            }
        }
        // the logic of the cancel 
        private void ClickCancel()
        {
            model.ReloadSettings();
            settings.Close();
        }
    }
}
