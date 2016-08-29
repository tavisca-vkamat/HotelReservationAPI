using FileLogManager;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NLog.Targets.Syslog;
namespace HotelReservationSystem
{
    public class LoggerExample
    {
        public static Logger loggerForRoomBooking = LogManager.GetLogger("roomBookingLogs");
        public static Logger loggerForApplication = LogManager.GetLogger("applicationLogs");
    

        public static void BookRoomLogs(LogEntry logentry, int bookingId)
        {
            string line = logentry.entryTime + " " + logentry.logMessage + " booking ID:"+bookingId.ToString();
            loggerForRoomBooking.Info(line);
        }

        public static void ApplicationLogs()
        {
            //loggerForApplication =

        }
    }
}
