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
    public class PretraIvanje
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
        public void ThePretraIvanjeTest()
        {
            driver.Navigate().GoToUrl("https://moodle.srce.hr/2024-2025/my/");
            driver.FindElement(By.LinkText("Moja naslovnica")).Click();
            driver.FindElement(By.XPath("//div[@id='searchinput-navbar-67a918fd023e667a918fcd627a8']/a/i")).Click();
            driver.FindElement(By.Id("searchinput-67a918fd023e667a918fcd627a8")).Clear();
            driver.FindElement(By.Id("searchinput-67a918fd023e667a918fcd627a8")).SendKeys("matematika");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.Navigate().GoToUrl("https://moodle.srce.hr/2024-2025/search/index.php?context=4007222&q=matematika");
            driver.FindElement(By.Id("yui_3_18_1_1_1739135244816_260")).Click();
            driver.Navigate().GoToUrl("https://moodle.srce.hr/2024-2025/search/index.php?page=1&q=matematika&title&timestart=0&timeend=0&mycoursesonly=0");
            driver.FindElement(By.Id("yui_3_18_1_1_1739135277837_257")).Click();
            driver.Navigate().GoToUrl("https://moodle.srce.hr/2024-2025/my/");
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
