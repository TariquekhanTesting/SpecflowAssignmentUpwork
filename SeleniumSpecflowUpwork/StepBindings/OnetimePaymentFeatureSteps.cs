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
    public class OnetimePaymentFeatureSteps
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


        [Given(@"User is navigated to Payment Link")]
        public void GivenUserIsNavigatedToPaymentLink()
        {
            //Navigate to URL
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            //Maximize window
            driver.Manage().Window.Maximize();
            //Wait for the Element to be visible
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Elements.onetimepayment)));
        }
        
        [Given(@"Click on Onetime button")]
        public void GivenClickOnOnetimeButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Elements.onetimepayment)));

            driver.FindElement(By.XPath(Elements.onetimepayment)).Click();
        }
        
        [When(@"user Enter Message Description")]
        public void WhenUserEnterMessageDescription()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Elements.MessageDescriptionField)));

            driver.FindElement(By.XPath(Elements.MessageDescriptionField)).SendKeys("Onetime Payment Automation");
        }


        [When(@"user Enter Payee and Card Details and Click Pay")]
        public void WhenUserEnterPayeeandcarddetails()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Elements.Name)));

            //Enter Card Name
            driver.FindElement(By.XPath(Elements.Name)).SendKeys("Tarique khan");

            //Enter Email
            driver.FindElement(By.XPath(Elements.Email)).SendKeys("Tarique@mailinator.com");

            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath(Elements.Frame)));

            //Enter Card Number
            driver.FindElement(By.XPath(Elements.CardNumber)).SendKeys("4242424242424242");

            //Enter Card Number
            driver.FindElement(By.XPath(Elements.CardExpDate)).SendKeys("0722");

            //Enter Card Number
            driver.FindElement(By.XPath(Elements.CVCNumber)).SendKeys("123");

            //Enter Zip 
            driver.FindElement(By.XPath(Elements.ZipNumber)).SendKeys("12345");

            //Back to default
            driver.SwitchTo().DefaultContent();

            //Click Pay Button
            driver.FindElement(By.XPath(Elements.PayButton)).Click();


        }




        [Then(@"Payment Success Message is Displayed")]
        public void ThenPaymentSuccessScreenDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Elements.SuccessMessage)));

            //Verify result is not lesser than 23
            Assert.IsTrue(driver.FindElement(By.XPath(Elements.SuccessMessage)).Displayed,"Payment Failed.!!Success Message not Displayed for the Payment");

            //Close driver
            driver.Close();
        }
    }
}
