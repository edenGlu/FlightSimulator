using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
    class AutoPilotModel : BaseNotify
    {
        private Brush textBack;
        private Sender sender;

        public AutoPilotModel()
        {
            sender = Singleton.Instance;
        }

        public string Text { get; set; }

        public Brush TextBack
        {
            get
            {
                return textBack;
            }
            set
            {
                textBack = value;
                NotifyPropertyChanged("TextBack");
            }
        }
        
        public void Ok()
        {
            TextBack = Brushes.IndianRed;
            String[] msgs = Text.Split('\n');
            for(int i = 0; i< msgs.Length; i++)
            {
                string msg = msgs[i];
                if(msg[msg.Length -1] == '\r')
                {
                    msg += '\n';
                }
                else
                {
                    msg += "\r\n";
                }
                sender.Send(msg);
                Thread.Sleep(2000);
            }
            TextBack = Brushes.White;
        }

    }
}
