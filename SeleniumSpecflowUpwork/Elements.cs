using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecflowUpwork
{
    class Elements
    {
        public static String URL = "https://www.oddsking.com/lotto/irish";
        public static String ResultButton = "//div[contains(text(),'Results')]/parent::div/a";
        public static String ViewFilteredResultButton = "//button[contains(text(),'View Filtered Results')]";
        public static String Date = "//button/abbr[contains(text(),'23')]";
        public static String FromDate = "//div[contains(text(),'FROM')]/parent::div/div[2]";
        public static String CalendarDoneButton = "//button[contains(text(),'Done')]";


        public static String firstresult = "//div[@class='_1sjkz1w']/div/div[1]";
    }
}
