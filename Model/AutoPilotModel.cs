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
    /*
     * class AutoPilotModel : 
     * the model to send massage to the simulator
     */
    class AutoPilotModel : BaseNotify
    {
        private Brush textBack; 
        private Sender sender;
        // constractor
        public AutoPilotModel()
        {
            // get the instans of the client that can send msg to the simulator
            sender = Singleton.Instance;
        }
        // proprty 
        public string Text { get; set; }
        // proprty
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
        // the ok buttom logic 
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
                Thread.Sleep(2000); // wait 2 sec beetwin msgs 
            }
            TextBack = Brushes.White;
        }

    }
}
