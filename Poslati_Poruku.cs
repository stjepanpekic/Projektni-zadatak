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
    public class PoslatiPoruku
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
        public void ThePoslatiPorukuTest()
        {
            driver.Navigate().GoToUrl("https://moodle.srce.hr/2024-2025/my/");
            driver.FindElement(By.LinkText("Moja naslovnica")).Click();
            driver.FindElement(By.XPath("//a[@id='message-drawer-toggle-67a91873b55d067a91873949f310']/i")).Click();
            driver.FindElement(By.XPath("//div[@id='view-overview-favourites-target-67a91873c2cd567a91873949f314']/div[2]/a/div/div")).Click();
            driver.FindElement(By.XPath("//div[@id='message-drawer-67a91873c2cd567a91873949f314']/div[4]/div/div/div[2]/textarea")).Click();
            driver.FindElement(By.Id("yui_3_18_1_1_1739135092970_50")).Clear();
            driver.FindElement(By.Id("yui_3_18_1_1_1739135092970_50")).SendKeys("Pozdrav!");
            driver.FindElement(By.XPath("//div[@id='yui_3_18_1_1_1739135092970_51']/div/button[2]/span/i")).Click();
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
