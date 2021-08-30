using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumSpecflowUpwork.TestUtilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumSpecflowUpwork.StepBindings
{
   
    [Binding]
    public class LastSevenDaysResultFeatureSteps
    {
        IWebDriver driver = GenricLib.getDriver(GenricLib.browser);
        public static ExtentReports Extent;
        public static ExtentTest Test;

        [OneTimeSetUp]
        public void StartReport()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\AutomationReport.html";
            Extent = new ExtentReports();
        }


        [Given(@"User is navigated to Oddsking Website")]
        public void GivenUserIsNavigatedToOddskingWebsite()
        {
            //Navigate to URL
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            //Maximize window
            driver.Manage().Window.Maximize();
            //Wait for the Element to be visible
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Elements.ResultButton)));
        }
        
        [Given(@"Click on result button")]
        public void GivenClickOnResultButton()
        {
            driver.FindElement(By.XPath(Elements.ResultButton)).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Elements.ViewFilteredResultButton)));

            //Move to View Filtered Result Button
            var element = driver.FindElement(By.XPath(Elements.ViewFilteredResultButton));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Build().Perform();           
        }
        
        [When(@"User selects date range of last seven days")]
        public void WhenUserSelectsDateRangeOfLastSevenDays()
        {
            //Click on From Date
            driver.FindElement(By.XPath(Elements.FromDate)).Click();

            //Select Date
            driver.FindElement(By.XPath(Elements.Date)).Click();

            //Click on Done Button
            driver.FindElement(By.XPath(Elements.CalendarDoneButton)).Click();

            //Click on the View filtered Results Button
            driver.FindElement(By.XPath(Elements.ViewFilteredResultButton)).Click();

            Thread.Sleep(5000);
        }

        [Then(@"results of last seven days are displayed")]
        public void ThenResultsOfLastSevenDaysAreDisplayed()
        {
            //Get Current Date
           String today = DateTime.Now.ToString("dd/MM/yyyy");

            // Date 7 days back
            int x=23;

            //Date of first result
            string a = driver.FindElement(By.XPath(Elements.firstresult)).Text;
            //Get first two characters of string
            string b = a.Substring(0, 2);          
            int myInt = int.Parse(b);
        
            //Verify result is not lesser than 23
            Assert.IsTrue(myInt>x);

            //Close driver
            driver.Close();
        }
    }
}
