using Microsoft.VisualStudio.TestTools.UnitTesting;

using RelevantCodes.ExtentReports;
using System.Configuration;
using System.Threading;
using TestAutomationFramework.BaseClass;
using TestAutomationFramework.Pages;
using TestAutomationFramework.Utility;

namespace TestAutomationFramework.Testscripts
{
    [TestClass]
    public class ContactsPageTest:TestBase
    {
        LoginPage loginpage;
        HomePage homepage;
        static TestUtil testutil;
        ContactsPage contactspage;
        static  ExtentReports reports;
        static  ExtentTest logger;

        public ContactsPageTest()
        {

        }

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            testutil = new TestUtil();
            reports = testutil.StartReporter();
            Initialize();
        }
        [TestInitialize]
        public void setUp()
        {
            string testMethodName = TestContext.TestName;
            logger = reports.StartTest(testMethodName);
            contactspage = new ContactsPage();
            loginpage = new LoginPage();
            homepage = loginpage.validateLogin(ConfigurationManager.AppSettings.Get("username"), ConfigurationManager.AppSettings.Get("password"));
            
            testutil.switchToFrame();
            // contactspage = homepage.clickonContactsLink();
            

        }

        [TestMethod]
        public void verifyContactsPageLabel()
        {
            Assert.IsTrue(contactspage.verifyContactslabel(),"contactslabel is missing in the page");
        }

        [TestMethod]
        public void selectContactsTest()
        {
            contactspage.selectContactsByName("aab nnn");
        }

        [TestMethod]
        public void validateCreateContact()
        {

            logger.Log(LogStatus.Info, "Starting Test");
            
            homepage.clickonContactsLink();
            Thread.Sleep(2500);          
            contactspage.createNewContact("Contacts");
            
            
            logger.Log(LogStatus.Pass, logger.AddScreenCapture(testutil.TakeScreenshot(driver, "CreateNewContact")));
            
        }
       

        [TestCleanup]
        public  void tearDown()
        {
            reports.EndTest(logger);
 
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            driver.Quit();
            testutil.endReporter();
        }
    }
}
