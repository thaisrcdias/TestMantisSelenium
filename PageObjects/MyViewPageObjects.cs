using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using TestMantisSelenium.Common;

namespace TestMantisSelenium.PageObjects
{
    public class MyViewPageObjects
    {
        #region Variáveis e Construtor
        WebDriverWait wait = null;
        int waitComponent;
        IWebDriver driver = null;

        public MyViewPageObjects(IWebDriver driverReference)
        {
            driver = driverReference;
            waitComponent = Convert.ToInt16(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).
                AppSettings.Settings["PageLoadTimeout"].Value);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitComponent));
        }

        #endregion

        #region Web Elements

        protected IWebElement ViewIssueLink => driver.FindElement(By.LinkText("View Issues"));
        protected IWebElement CSVExportLink => driver.FindElement(By.LinkText("CSV Export"));
        //protected IWebElement UnassignedIssues => driver.FindElement(By.LinkText("Unassigned"));

        //  protected IWebElement UnassignedIssues => driver.FindElement(By.XPath("//a[contains(text(),'Unassigned')]"));

        protected IWebElement UnassignedIssues => driver.FindElement(By.CssSelector("body > div:nth-child(5) > table.hide > tbody > tr:nth-child(1) > td:nth-child(1) > table > tbody > tr:nth-child(1) > td > a"));

        #endregion

        #region Methods

        public void ClickOnViewIssues()
        {
            wait.Until(UtilSelenium.ElementIsVisible(ViewIssueLink));
            ViewIssueLink.Click();
        }

        public void ClickOnUnassignedIssues()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(UnassignedIssues));
                NUnit.Framework.Assert.AreEqual("Unassigned", UnassignedIssues.Text);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }

        public void ClickOnExcelExportLink()
        {
            wait.Until(UtilSelenium.ElementIsVisible(CSVExportLink));
            CSVExportLink.Click();
        }

        #endregion

    }
}
