using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Configuration;
using Dapper;
using System.Linq;
using TestAutomationFramework.BaseClass;
using System.Data.OleDb;

namespace TestAutomationFramework.Utility
{
    public class TestUtil:TestBase
    {
       public  ExtentReports reports;
       public ExtentTest test;

        
        
        public void switchToFrame()
        {
            driver.SwitchTo().Frame("mainpanel");
        }

        public string TakeScreenshot(IWebDriver driver, string screenShotName)
        {

            ITakesScreenshot src = ((ITakesScreenshot)driver);
            Screenshot screenshot = src.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualpath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshots\\" +screenShotName + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".jpeg";
            string projectpath = new Uri(actualpath).LocalPath;
            screenshot.SaveAsFile(projectpath,ScreenshotImageFormat.Jpeg);
            return projectpath;

        }

        public ExtentReports StartReporter()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualpath = path.Substring(0, path.LastIndexOf("bin"));
            string projectpath = new Uri(actualpath).LocalPath;

            string reportPath = projectpath + "Reports\\MyOwnReport.html";
            reports = new ExtentReports(reportPath, true);            
            
            reports.AddSystemInfo("Environment", "QA")
                .AddSystemInfo("Username", "Debasis")
                .AddSystemInfo("Host Name", "Debasis")
                .AddSystemInfo("Report Head Line","Test Automation");

            reports.LoadConfig(projectpath + "extent-config.xml");

            return reports;


        }

        public void endReporter()
        {
            reports.Flush();
            reports.Close();
        }
    }
}
