using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Tests1.BaseClass;
using NUnit.Tests1.PageObjects;
using OpenQA.Selenium;

namespace NUnit.Tests1.TestScripts
{
    [TestFixture]

    class Module1 :BaseTest
    {
        [Test,Author("Mohamed AlQadeery","moh9amad1@gmail.com")]
        [Category("Imdb website"),Description("Testing searching for movies")]
        public void search_movie_test()
        {
            try
            {
                test.Log(Status.Info, "Redirect to Imdb website");

                var searchPage = new SearchPage(driver);
                var resultPage = searchPage.NavigateToResultPage();
                test.Log(Status.Info, "Search button clicked");

                test.Log(Status.Info, "Redirect to result page ");

                var moviePage = resultPage.NavigateToMoviePage();
                test.Log(Status.Info, "Redirect to moviepage");

                String expected_title = "Harry Potter and the Goblet of Fire";
                String actual_title = moviePage.getMovieTitle();

                Assert.AreEqual(expected_title, actual_title);
                test.Log(Status.Pass, "Test passed");

            }
            catch (Exception e)
            {
                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile("C:\\Users\\Gf63\\source\\repos\\NUnit.Tests1\\NUnit.Tests1\\Screenshots\\s1.jpeg"
                    , ScreenshotImageFormat.Jpeg);

                Console.WriteLine(e.StackTrace);
                test.Log(Status.Fail, "Test Failed");

                throw;
            }
            finally
            {
                if (driver != null)
                {
                    driver.Close();

                }
            }
            
          

        }
    }
}
