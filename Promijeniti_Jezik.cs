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
    public class PromijenitiJezik
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
        public void ThePromijenitiJezikTest()
        {
            driver.Navigate().GoToUrl("https://moodle.srce.hr/2024-2025/my/");
            driver.FindElement(By.LinkText("Moja naslovnica")).Click();
            driver.FindElement(By.Id("user-menu-toggle")).Click();
            driver.FindElement(By.LinkText("Postavke")).Click();
            driver.Navigate().GoToUrl("https://moodle.srce.hr/2024-2025/user/preferences.php");
            driver.FindElement(By.XPath("//section[@id='region-main']/div/div/div/div/div/div/div/div[2]/a")).Click();
            driver.Navigate().GoToUrl("https://moodle.srce.hr/2024-2025/user/language.php?id=212224&course=1");
            driver.FindElement(By.Id("id_lang")).Click();
            new SelectElement(driver.FindElement(By.Id("id_lang"))).SelectByText("English ‎(en)‎");
            driver.FindElement(By.Id("id_submitbutton")).Click();
            driver.Navigate().GoToUrl("https://moodle.srce.hr/2024-2025/user/preferences.php?userid=212224");
            driver.FindElement(By.LinkText("Dashboard")).Click();
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
