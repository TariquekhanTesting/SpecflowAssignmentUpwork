using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecflowUpwork
{
    class Elements
    {
        public static String URL = "https://limepay-qa-tests-kgwfq2pfigxkt.herokuapp.com/alexmamonchik/payme";
        public static String onetimepayment = "//a[contains(text(),'One time')]";
        public static String MessageDescriptionField = "//textarea[@id='message-text']";
        public static String Name = "//input[@name='business_name']";
        public static String Email = "//input[@name='email']";
        public static String CardNumber = "//input[@name='cardnumber']";
        public static String CardExpDate = "//input[@name='exp-date']";
        public static String CVCNumber = "//input[@name='cvc']";
        public static String ZipNumber = "//input[@name='postal']";
        public static String PayButton = "//button[@id='mtrPayMePagePayBtn']";
        public static String Frame = "//div[@id='card-element']/div/iframe";
        public static String SuccessMessage = "//p[contains(text(),'Thank you!')]";
    }
}
