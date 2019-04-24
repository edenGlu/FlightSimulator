using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class Singleton
    {
        private static readonly Sender instance = new Sender();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton()
        {
        }

        Singleton()
        {
        }

        /// <summary>
        /// The public Instance property to use
        /// </summary>
        public static Sender Instance
        {
            get { return instance; }
        }
    }
}
