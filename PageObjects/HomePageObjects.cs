using Microsoft.VisualBasic.CompilerServices;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Reflection;
using System.Threading;
using TestMantisSelenium.Common;

namespace TestMantisSelenium.PageObjects
{
    public class HomePageObjects
    {
        #region Variáveis e Construtor
        WebDriverWait wait = null;
        int waitComponent;
        IWebDriver driver = null;

        public HomePageObjects(IWebDriver driverReference)
        {
            driver = driverReference;
            waitComponent = Convert.ToInt16(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).
                AppSettings.Settings["PageLoadTimeout"].Value);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitComponent));
        }
        #endregion

        #region Web Elements

        #region Select Project

        protected IWebElement ChooseProjectComboBox => driver.FindElement(By.Name("project_id"));
        protected IWebElement SubmitProjectButton => driver.FindElement(By.XPath("//input[@value='Switch']"));

        #endregion

        protected IWebElement LogoutLink => driver.FindElement(By.LinkText("Logout"));

        protected IWebElement IssueId => driver.FindElement(By.Name("bug_id"));

        protected IWebElement ButtonJump => driver.FindElement(By.XPath("//input[@value='Jump']"));

        protected IWebElement NotFoundIssue => driver.FindElement(By.XPath("//p"));

        #endregion

        public void ChoiceMyProject(string projeto)
        {
            wait.Until(UtilSelenium.ElementIsVisible(ChooseProjectComboBox));
            var selectElement = new SelectElement(ChooseProjectComboBox);
            selectElement.SelectByText(projeto);
        }
        public void ClickSelectProjectButton()
        {
            wait.Until(UtilSelenium.ElementIsVisible(SubmitProjectButton));
            SubmitProjectButton.Click();
        }

        public void ClickOnLogout()
        {
            wait.Until(UtilSelenium.ElementIsVisible(LogoutLink));
            LogoutLink.Click();
        }
        public void FillIssueField(string issueId)
        {
            wait.Until(UtilSelenium.ElementIsVisible(IssueId));
            IssueId.SendKeys(issueId);
        }
        public void ClickOnJump()
        {
            wait.Until(UtilSelenium.ElementIsVisible(ButtonJump));
            ButtonJump.Click();
        }

        public void CheckIssueNonExistent(string ID)
        {
            string text = "Issue " + ID + " not found.";
            wait.Until(ExpectedConditions.ElementToBeClickable(NotFoundIssue));
            Assert.AreEqual(text, NotFoundIssue.Text);

        }
    }
}
