using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecflowUpwork.TestUtilities
{
    class GenricLib
    {
        public static IWebDriver driver;
        // Excel file to Define browser name
        public static String browser = BusinessLib.getData(2,1);

        public static void invokeBrowser(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Elements.URL);
            driver.Manage().Window.Maximize();

        }
        public static IWebDriver getDriver(String browserName)
        {

            if (browserName.Equals("firefox"))
            {               
                driver = new FirefoxDriver();
            }
            else if (browserName.Equals("chrome"))
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("intl.accept_languages", "en");
                chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                driver = new ChromeDriver(chromeOptions);
            }

            return driver;
        }

        public static void TakeScreenShot(string fileName, IWebDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            screenshot.SaveAsFile(@ConfigurationManager.AppSettings["ScreenshotPath"] + fileName + ".png", ScreenshotImageFormat.Png);

        }
    }
}
