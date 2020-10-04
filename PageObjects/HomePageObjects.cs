using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Reflection;
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

     

        [FindsBy(How = How.Name, Using = "bug_id")]
        public IWebElement tfBugId { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Jump']")]
        public IWebElement btJump { get; set; }

        [FindsBy(How = How.XPath, Using = "//p")]
        public IWebElement tfErro { get; set; }

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


    }
}
