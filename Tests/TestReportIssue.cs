using NUnit.Framework;
using System.Configuration;
using System.Reflection;
using TestMantisSelenium.BaseClass;
using TestMantisSelenium.Helpers;
using TestMantisSelenium.PageObjects;

namespace TestMantisSelenium.Tests
{
    [TestFixture]
    public class TestReportIssue : TestBase
    {
        [Test]
        [Category("CT")]
        public void ReportIssue()
        {
            Login login = new Login();
            login.DoLogin(driver);

            ReportIssuePageObjects report = new ReportIssuePageObjects(driver);
            report.ClickOnReportIssueLink();
            report.CreateNewReport(ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                .AppSettings.Settings["MeuProjeto"].Value,  "[All Projects] a", "Teste Thais", "Teste");
            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
