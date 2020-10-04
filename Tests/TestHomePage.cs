using NUnit.Framework;
using System.Configuration;
using System.Reflection;
using TestMantisSelenium.BaseClass;
using TestMantisSelenium.Helpers;
using TestMantisSelenium.PageObjects;

namespace TestMantisSelenium.Tests
{
    [TestFixture]
    public class TestHomepage : TestBase
    {
        [Test]
        [Category("CT")]
        public void ChoiceProject()
        {
            Login login = new Login();
            login.DoLogin(driver);
            HomePageObjects homePageObjects = new HomePageObjects(driver);
            
            homePageObjects.ChoiceMyProject(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                .AppSettings.Settings["MeuProjeto"].Value);
            homePageObjects.ClickSelectProjectButton();
            homePageObjects.ChoiceMyProject(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                .AppSettings.Settings["TodosProjetos"].Value);
            homePageObjects.ClickSelectProjectButton();

            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        [Category("CT")]
        public void SearchIssue()
        {
            Login login = new Login();
            login.DoLogin(driver);
            HomePageObjects homePageObjects = new HomePageObjects(driver);
            homePageObjects.FillIssueField("4871");
            homePageObjects.ClickOnJump();
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        [Category("CT")]
        public void SearchNonExistentIssue()
        {
            Login login = new Login();
            login.DoLogin(driver);
            HomePageObjects homePageObjects = new HomePageObjects(driver);
            homePageObjects.FillIssueField("999999899");
            homePageObjects.ClickOnJump();
            homePageObjects.CheckIssueNonExistent("999999899");
            Assert.AreEqual("", verificationErrors.ToString());
        }


        [Test]
        [Category("CT")]
        public void Logout()
        {
            HomePageObjects homePageObjects = new HomePageObjects(driver);
            Login login = new Login();
            login.DoLogin(driver);
            homePageObjects.ClickOnLogout();
            Assert.AreEqual("", verificationErrors.ToString());
        }

    }
}
