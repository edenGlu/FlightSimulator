using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    /*
     * class IServer :
     * responseble to create one server in the pograme. 
     */
    class IServer
    {
        // the only one that create a new server
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
