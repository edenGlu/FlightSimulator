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
using FlightSimulator.Views.Windows;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.ViewModels
{
    class FlightMonitorViewModel : BaseNotify
    {
        private ICommand _settingCommand;
        private ICommand _connectCommand;
        private Settings settings;

        public FlightMonitorViewModel()
        {
            settings = new Settings();
        }

        public ICommand SettingCommand
        {
            get
            {
                return _settingCommand ?? (_settingCommand = new CommandHandler(() => ClickSetting()));
            }
        }

        public void ClickSetting()
        {
            settings = new Settings();
            settings.Show(); 
        }

        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => ClickConnect()));
            }
        }

        private void ClickConnect()
        {
            ISettingsModel model = ApplicationSettingsModel.Instance;
            Sender send = Singleton.Instance;
            Server server = IServer.Instance;
            server.Connect(model.FlightServerIP, model.FlightInfoPort);
            send.Connect(model.FlightCommandPort, model.FlightServerIP);
        }
    }
}
