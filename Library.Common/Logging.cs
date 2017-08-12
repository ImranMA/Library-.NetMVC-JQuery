using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Library.Common
{
    public class Logging
    {

        //Log4net framework is used for logging
        private static readonly ILog _logger = LogManager.GetLogger("Library.Logging");


        //Initializing the Log4net with configurations defined in Web.config
        static Logging()
        {
            log4net.Config.XmlConfigurator.Configure();
        }


        //I have only implemented some of the methods, we can extend logging here
        public static void Debug(string Message)
        {
            _logger.Debug(Message);
        }


        public static void Error(string Message)
        {
            _logger.Debug(Message);
        }


        public static void Info(string Message)
        {
            _logger.Info(Message);
        }



    }
}
