using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUnit.Tests1.PageObjects
{
  public  class ResultPage
    {
        IWebDriver driver;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.LinkText, Using = "Harry Potter and the Goblet of Fire")]
        public IWebElement MovieLink { get; set; }

        public MoviePage NavigateToMoviePage()
        {
            Thread.Sleep(4000);// wait for 4 sec for the page to load
            this.MovieLink.Click();
            return new MoviePage(driver);
        }
    }
}
