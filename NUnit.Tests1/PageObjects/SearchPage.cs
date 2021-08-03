using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NUnit.Tests1.PageObjects
{
   public class SearchPage
    {
        IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.XPath,Using = "/html/body/div[2]/nav/div[2]/div[1]/form/div[2]/div/input")]
        public IWebElement SearchTextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#suggestion-search-button")]
        public IWebElement SearchButton { get; set; }


        public ResultPage NavigateToResultPage()
        {
            this.SearchTextBox.SendKeys("Harry Potter and the goblet of fire");
            this.SearchButton.Click();
            return new ResultPage(driver);
        }

    }
}
