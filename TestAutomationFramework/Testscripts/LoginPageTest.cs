using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.BaseClass;
using TestAutomationFramework.Pages;
using TestAutomationFramework.Properties;
using System.Configuration;

namespace TestAutomationFramework.Testscripts
{
    [TestClass]
    public class LoginPageTest:TestBase
    {
        LoginPage loginpage;
        public LoginPageTest()
        {
            
        }
        [TestInitialize]
        public void setUp()
        {
            Initialize();
            loginpage = new LoginPage();

        }
        

        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }

        [TestMethod]

        public void loginTitleTest()
        {
            
            String title = loginpage.validateLoginPageTitle();
            Assert.AreEqual(title,"#1 Free CRM for Any Business: Online Customer Relationship Software");

        }

        [TestMethod]
        public void crmloginImageTest()
        {
           Boolean flag =  loginpage.validatecrmImage();
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void loginTest()
        {
            loginpage.validateLogin(ConfigurationManager.AppSettings.Get("username"), ConfigurationManager.AppSettings.Get("password"));
        }


    }
}
