using NUnit.Framework;
using TestMantisSelenium.BaseClass;
using TestMantisSelenium.Helpers;

namespace TestMantisSelenium
{
    [TestFixture]
    public class TestLogin : TestBase
    {
        [Test]
        [Category("CT")]
        public void LoginSucess()
        {
            Login login = new Login();
            login.DoLogin(driver);
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        [Category("CT")]
        public void LoginFail()
        {
            Login login = new Login();
            login.DoFailLogin(driver);
            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}