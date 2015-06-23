using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBitz.EasyXLR.LogManager
{
    public class LogLocator
    {
        /// <summary>
        /// Returns the Log4Net object
        /// </summary>	
        /// <returns>Log4Net object</returns>
        /// not yet configure .. need to add configuraion
        public static ILogger GetLogger(Type type)
        {
            return new LogManager(type);
        }



    }
}
