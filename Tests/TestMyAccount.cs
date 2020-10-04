using NUnit.Framework;
using System.Configuration;
using System.Reflection;
using TestMantisSelenium.BaseClass;
using TestMantisSelenium.Helpers;
using TestMantisSelenium.PageObjects;

namespace TestMantisSelenium.Tests
{
    [TestFixture]
    public class TestMyAccount : TestBase
    {
        [Test]
        [Category("CT")]
        public void MyAccount()
        {
            Login login = new Login();
            login.DoLogin(driver);

            MyAccountPageObjects myAccountPageObjects = new MyAccountPageObjects(driver);
            myAccountPageObjects.ClickOnMyAccount();
            myAccountPageObjects.FillRealnamefField(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly()
                .Location).AppSettings.Settings["RealName"].Value);
            myAccountPageObjects.ClickOnSubmitButton();

            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
