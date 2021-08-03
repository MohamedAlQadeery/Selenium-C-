using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NUnit.Tests1.PageObjects
{
   public  class MoviePage
    {

        public IWebDriver driver;
        [FindsBy(How =How.XPath,Using = "/html/body/div[2]/main/div/section[1]/section/div[3]/section/section/div[1]/div[1]/h1")]
        public IWebElement MovieTitle { get; set; }

        public MoviePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public String getMovieTitle()
        {
            return this.MovieTitle.Text;
        }


    }
}
