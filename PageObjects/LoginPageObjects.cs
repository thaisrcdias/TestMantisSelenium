using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Reflection;
using TestMantisSelenium.Common;

namespace TestMantisSelenium.PageObjects
{
    public class LoginPageObjects
    {
        #region Variáveis e Construtor
        WebDriverWait wait = null;
        int waitComponent;
        IWebDriver driver = null;

        public LoginPageObjects(IWebDriver driverReference)
        {
            driver = driverReference;
            waitComponent = Convert.ToInt16(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).
                AppSettings.Settings["PageLoadTimeout"].Value);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitComponent));
        }

        #endregion

        #region Web Elements

        protected IWebElement UserNameField => driver.FindElement(By.Name("username"));
        protected IWebElement PasswordField => driver.FindElement(By.Name("password"));
        protected IWebElement LoginButton => driver.FindElement(By.XPath("//input[@value='Login']"));
        protected IWebElement LoggedInUserLabel => driver.FindElement(By.ClassName("login-info-left"));

        #endregion

        public void FillUsernameField(string username)
        {
            wait.Until(UtilSelenium.ElementIsVisible(UserNameField));
            UserNameField.SendKeys(username);
        }

        public void FillPasswordField(string password)
        {
            wait.Until(UtilSelenium.ElementIsVisible(UserNameField));
            PasswordField.SendKeys(password);
        }

        public void ClickOnLoginButton()
        {
            wait.Until(UtilSelenium.ElementIsVisible(LoginButton));
            LoginButton.Click();
        }

        public void WrongLogin()
        {
            Assert.IsFalse(Is_LoggedInUserLabel_Visible());
            //Assert.AreEqual(TxtWrongLogin, "Your account may be disabled or blocked or the username/password you entered is incorrect.");
        }
     
        public bool Is_LoggedInUserLabel_Visible()
        {
            try
            {
                return LoggedInUserLabel.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
