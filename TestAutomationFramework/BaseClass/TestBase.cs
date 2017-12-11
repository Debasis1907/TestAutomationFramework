using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestAutomationFramework.BaseClass
{
  public  class TestBase
    {
        public static IWebDriver driver;
        

        public  TestBase()
        {
            
        }
        [AssemblyInitialize]
        public static void Initialize()
        {
            string browserName = ConfigurationManager.AppSettings.Get("browser");
            if (browserName.Equals("chrome"))
            {
                driver = new ChromeDriver();
            }
            else if (browserName.Equals("FF"))
            {
                driver = new FirefoxDriver();
            }

            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);            

            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("url"));
            Thread.Sleep(2000);
        }
    }

    
}
