using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Reflection;
using System.Text;
using TestMantisSelenium.Common;

namespace TestMantisSelenium.PageObjects
{
    public class MyAccountPageObjects
    {
        #region Variáveis e Construtor
        WebDriverWait wait = null;
        int waitComponent;
        IWebDriver driver = null;

        public MyAccountPageObjects(IWebDriver driverReference)
        {
            driver = driverReference;
            waitComponent = Convert.ToInt16(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).
                AppSettings.Settings["PageLoadTimeout"].Value);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitComponent));
        }

        #endregion

        #region Web Elements

        protected IWebElement MyAccountLink => driver.FindElement(By.LinkText("My Account"));
        protected IWebElement MyRealName => driver.FindElement(By.XPath("//input[@name='realname']"));
        protected IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@value='Update User']"));


        #endregion

        #region Methods

        public void ClickOnMyAccount()
        {
            wait.Until(UtilSelenium.ElementIsVisible(MyAccountLink));
            MyAccountLink.Click();
        }

        public void FillRealnamefField(string realname)
        {
            wait.Until(UtilSelenium.ElementIsVisible(MyRealName));
            MyRealName.Clear();
            MyRealName.SendKeys(realname);
        }

        public void ClickOnSubmitButton()
        {
            wait.Until(UtilSelenium.ElementIsVisible(UpdateButton));
            UpdateButton.Click();
        }

        #endregion

    }
}
