using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace NUnit.Tests1.BaseClass
{
    public class BaseTest
    {
        
        public IWebDriver driver;
        public ExtentReports extent_report = null;
        public ExtentTest test = null;


        [OneTimeSetUp]
        public void open()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.imdb.com/";
            this.start_report();
            test = extent_report.CreateTest("IMDB test").Info("Test started");
            test.Log(Status.Info, "Chrome browser opend");


        }

        [OneTimeTearDown]
        public void close()
        {
            test.Log(Status.Info, "End of the test");

            driver.Quit();
            this.end_report();


        }

        [OneTimeSetUp]
        private void start_report()
        {
            extent_report = new ExtentReports();
            var htmlReport = new ExtentHtmlReporter(@"C:\\Users\\Gf63\\source\\repos\\NUnit.Tests1\\NUnit.Tests1\\Reports\\BaseTest.html");
            extent_report.AttachReporter(htmlReport);
        }

        [OneTimeTearDown]
        private void end_report()
        {
            extent_report.Flush();
        }
    }
}
