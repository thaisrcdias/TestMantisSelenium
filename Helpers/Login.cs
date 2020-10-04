using OpenQA.Selenium;
using System.Configuration;
using System.Reflection;
using TestMantisSelenium.PageObjects;

namespace TestMantisSelenium.Helpers
{
    public class Login 
    {
        public void DoLogin(IWebDriver driver)
        {
            LoginPageObjects loginPageObjects = new LoginPageObjects(driver);
            loginPageObjects.FillUsernameField(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                .AppSettings.Settings["Username"].Value);
            loginPageObjects.FillPasswordField(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                .AppSettings.Settings["Password"].Value);
            loginPageObjects.ClickOnLoginButton();
        }

        public void DoFailLogin(IWebDriver driver)
        {
            LoginPageObjects loginPageObjects = new LoginPageObjects(driver);
            loginPageObjects.FillUsernameField(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).
                AppSettings.Settings["Username"].Value);
            loginPageObjects.FillPasswordField(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).
                AppSettings.Settings["WrongPassword"].Value);
            loginPageObjects.ClickOnLoginButton();
            loginPageObjects.WrongLogin();
        }
    }
}
