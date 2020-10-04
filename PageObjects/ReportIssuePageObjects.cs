using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
    public class ReportIssuePageObjects
    {
        #region Variáveis e Construtor
        WebDriverWait wait = null;
        int waitComponent;
        IWebDriver driver = null;

        public ReportIssuePageObjects(IWebDriver driverReference)
        {
            driver = driverReference;
            waitComponent = Convert.ToInt16(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).
                AppSettings.Settings["PageLoadTimeout"].Value);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitComponent));

        }

        #endregion

        #region Web Elements

        protected IWebElement ReportIssueLink => driver.FindElement(By.LinkText("Report Issue"));

        #endregion

        #region Select Project

        protected IWebElement ChooseProjectComboBox => driver.FindElement(By.Name("project_id"));
        protected IWebElement SelectProjectButton => driver.FindElement(By.ClassName("button"));
        protected IWebElement FormTitleLabel => driver.FindElement(By.ClassName("form-title"));

        #endregion

        #region Report Details

        protected IWebElement CategoryComboBox => driver.FindElement(By.Name("category_id"));
        protected IWebElement SummaryTextField => driver.FindElement(By.Name("summary"));
        protected IWebElement DescriptionTextField => driver.FindElement(By.Name("description"));
        protected IWebElement SubmitReportButton => driver.FindElement(By.CssSelector("input[value='Submit Report']"));

        #endregion

        #region Methods

        public void ClickOnReportIssueLink()
        {
            wait.Until(UtilSelenium.ElementIsVisible(ReportIssueLink));
            ReportIssueLink.Click();
        }

        public bool IsFormTitleVisible()
        {
            return FormTitleLabel.Displayed;
        }

        public void SelectProject(string project)
        {
            wait.Until(UtilSelenium.ElementIsVisible(ChooseProjectComboBox));
            var selectElement = new SelectElement(ChooseProjectComboBox);
            selectElement.SelectByText(project);
        }

        public void ClickSelectProjectButton()
        {
            wait.Until(UtilSelenium.ElementIsVisible(SelectProjectButton));
            SelectProjectButton.Click();
        }

        public void SelectCategory(string category)
        {
            wait.Until(UtilSelenium.ElementIsVisible(CategoryComboBox));
            var selectElement = new SelectElement(CategoryComboBox);
            selectElement.SelectByText(category);
        }

        public void FillSummaryField(string summary)
        {
            wait.Until(UtilSelenium.ElementIsVisible(SummaryTextField));
            SummaryTextField.SendKeys(summary);
        }

        public void FillDescriptionField(string description)
        {
            wait.Until(UtilSelenium.ElementIsVisible(DescriptionTextField));
            DescriptionTextField.SendKeys(description);
        }

        public void ClickSubmitReportButton()
        {
            wait.Until(UtilSelenium.ElementIsVisible(SubmitReportButton));
            Actions actions = new Actions(driver);
            actions.MoveToElement(SubmitReportButton);
            actions.Perform();
            SubmitReportButton.Click();
        }

        public void CreateNewReport(string project, string category, string summary, string description)
        {
            if (IsFormTitleVisible())
            {
                SelectProject(project);
                ClickSelectProjectButton();
            }
            SelectCategory(category);
            FillSummaryField(summary);
            FillDescriptionField(description);
            ClickSubmitReportButton();
        }

        #endregion
    }
}
