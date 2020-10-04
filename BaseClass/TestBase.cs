using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace TestMantisSelenium.BaseClass
{
    public class TestBase
    {
        public IWebDriver driver = null;
        public StringBuilder verificationErrors;

        [SetUp]
        public void CreateInstance()
        {
            string navegador = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                .AppSettings.Settings["NavegadorDefault"].Value;
            string baseURL = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                .AppSettings.Settings["URL"].Value;
            verificationErrors = new StringBuilder();

            switch (navegador)
            {
                case ("Firefox"):
                    driver = new FirefoxDriver();
                    driver.Navigate().GoToUrl(baseURL);
                    driver.Manage().Window.Maximize();
                    break;

                case ("Chrome"):
                    driver = new ChromeDriver();
                    driver.Navigate().GoToUrl(baseURL);
                    driver.Manage().Window.Maximize();
                    break;

                case ("InternetExplorer"):
                    driver = new InternetExplorerDriver();
                    driver.Navigate().GoToUrl(baseURL);
                    driver.Manage().Window.Maximize();
                    break;

                default:
                    break;
            }
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
    }
}
