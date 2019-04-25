using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.Views;
using System.Windows.Media;
using System.ComponentModel;
using System.Threading;

namespace FlightSimulator.ViewModels
{
    // class AutoPilotViewModle :
    // responsibel to view for the model and model foe the view
    class AutoPilotViewModle : BaseNotify
    {
        private ICommand _clearCommand;
        private ICommand _okCommand;
        private AutoPilotModel model;
        
        // constractor
        public AutoPilotViewModle() {
            model = new AutoPilotModel(); // create the modle
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        // command for the clear buttom 
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => ClickClear()));
            }
        }
        // proprty
        public String VM_TextBoxCommands
        {
            get
            {
                return model.Text;
            }
            set
            {
                model.Text = value;
                NotifyPropertyChanged("VM_TextBoxCommands");
            }
        }
        // the logic for clear buttom
        private void ClickClear()
        {
            VM_TextBoxCommands = "";
        }

        // Command for the ok buttom 
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => ClickOk()));
            }
        }
        // proprty
        public Brush VM_TextBack
        {
            get
            {
                return model.TextBack;
            }
            set
            {
                model.TextBack = value;
                NotifyPropertyChanged("VM_TextBack");
            }
        }

        // the logic for the ok buttom 
        private void ClickOk()
        {
            // send the msg in new thread
            Thread thread = new Thread(model.Ok);
            thread.Start();
        }

    }
}
