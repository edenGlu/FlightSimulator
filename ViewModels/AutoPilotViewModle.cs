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
    class AutoPilotViewModle : BaseNotify
    {
        private ICommand _clearCommand;
        private ICommand _okCommand;
        private AutoPilotModel model;

        public AutoPilotViewModle() {
            model = new AutoPilotModel();
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => ClickClear()));
            }
        }

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

        private void ClickClear()
        {
            VM_TextBoxCommands = "";
        }

        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => ClickOk()));
            }
        }

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


        private void ClickOk()
        {
            Thread thread = new Thread(model.Ok);
            thread.Start();
        }

    }
}
