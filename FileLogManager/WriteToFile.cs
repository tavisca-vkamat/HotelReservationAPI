using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogManager
{
    public class WriteToFile
    {

        public static void searchHotelByCustomer(LogEntry logentry)
        {
            try
            {
                //using (StreamWriter sw = new StreamWriter("..\\..\\..\\FileLogManager\\LogFiles\\HotelSearchLogs.txt"))
                //{
                //    string line = logentry.entryTime+" "+logentry.logMessage;
                //    sw.WriteLine(line);
                //}
                string line = logentry.entryTime + " " + logentry.logMessage+"\n";
                
                File.AppendAllText("..\\..\\..\\FileLogManager\\LogFiles\\HotelSearchLogs.txt", line);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
    }
}
