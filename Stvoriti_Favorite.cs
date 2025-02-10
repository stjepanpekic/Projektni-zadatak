using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class StvaranjeFavorita
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheStvaranjeFavoritaTest()
        {
            driver.Navigate().GoToUrl("https://moodle.srce.hr/2024-2025/my/");
            driver.FindElement(By.XPath("//div[@id='page-container-2']/div/div/div/div/div[2]/div/div/button/i")).Click();
            driver.FindElement(By.XPath("//div[@id='yui_3_18_1_1_1739134233220_40']/div/a")).Click();
            driver.FindElement(By.XPath("//div[@id='yui_3_18_1_1_1739134233220_45']/div[2]/div/div[2]/div/div/button/i")).Click();
            driver.FindElement(By.XPath("//div[@id='yui_3_18_1_1_1739134233220_55']/div/a")).Click();
            driver.FindElement(By.Id("yui_3_18_1_1_1739134233220_38")).Click();
            driver.FindElement(By.XPath("//div[@id='yui_3_18_1_1_1739134233220_52']/a[2]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
