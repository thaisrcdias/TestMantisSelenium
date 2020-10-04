using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Reflection;
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

        //protected IWebElement UnassignedIssues => driver.FindElement(By.XPath("//a[contains(text(),'Unassigned')]"));
        protected IWebElement UnassignedIssues => driver.FindElement(By.CssSelector("body>div:nth-child(5)>table.hide>tbody>tr:nth-child(1)>td:nth-child(1)>table>tbody>tr:nth-child(1)>td>a"));

        #endregion

        #region Methods

        public void ClickOnViewIssues()
        {
            wait.Until(UtilSelenium.ElementIsVisible(ViewIssueLink));
            ViewIssueLink.Click();
        }

        public void ClickOnUnassignedIssues()
        {
           // IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
           // js.ExecuteAsyncScript("document.querySelector('body>div:nth-child(5)>table.hide>tbody>tr:nth-child(1)>td:nth-child(1)>table>tbody>tr:nth-child(1)>td>a').click();");
            wait.Until(ExpectedConditions.ElementToBeClickable(UnassignedIssues));
            Assert.AreEqual("Unassigned", UnassignedIssues.Text);
        }

        public void ClickOnCSVExportLink()
        {
            wait.Until(UtilSelenium.ElementIsVisible(CSVExportLink));
            CSVExportLink.Click();
        }

        #endregion

    }
}
