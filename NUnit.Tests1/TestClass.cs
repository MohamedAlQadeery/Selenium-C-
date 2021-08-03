// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Tests1.BaseClass;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass : BaseTest
    {
        ExtentReports extent = null;
        [OneTimeSetUp]
        public void start_report()
        {
            extent = new ExtentReports();
            var htmlReport = new ExtentHtmlReporter(@"C:\\Users\\Gf63\\source\\repos\\NUnit.Tests1\\NUnit.Tests1\\Reports\\TestClass.html");
            extent.AttachReporter(htmlReport);
        }
        
        [OneTimeTearDown]
        public void end_report()
        {
            extent.Flush();
        }
        
        
        [Test,Category("Youtube Test")]
        [Author("Mohamed AlQadeery","moh9amad1@gmail.com")]
        public void youtubeTest()
        {
            ExtentTest test = null;
            try
            {
                 test = extent.CreateTest("Youtube test").Info("Test started");
                test.Log(Status.Info, "Chrome browser opend");
                IWebElement search_box = driver.FindElement(By.XPath("//*[@id='search']"));
                search_box.SendKeys("C#");
                test.Log(Status.Info, "Entered in search field");

                IWebElement search_button = driver.FindElement(By.XPath("/html/body/ytd-app/div/div/ytd-masthead/div[3]/div[2]/ytd-searchbox/form/button"));
                search_button.Click();
                test.Log(Status.Info, "Search button clicked");
                test.Log(Status.Pass, "Test passed");

            }
            catch (Exception e)
            {
                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile("C:\\Users\\Gf63\\source\\repos\\NUnit.Tests1\\NUnit.Tests1\\Screenshots\\s1.jpeg"
                    ,ScreenshotImageFormat.Jpeg);

                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                if(driver != null)
                {
                    driver.Close();

                }
            }
          
        }


    }
}
