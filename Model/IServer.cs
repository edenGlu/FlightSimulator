using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    class IServer
    {
        private static readonly Server instance = new Server();

        static IServer()
        {
        }

        IServer()
        {
        }

        /// <summary>
        /// The public Instance property to use
        /// </summary>
        public static Server Instance
        {
            get { return instance; }
        }

    }
}
