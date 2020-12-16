using System;
using System.Collections.Generic;
using System.Text;
using ApplitoolsRCA.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ApplitoolsRCA.PageServices
{
    public class HomePage
    {
        private static IJavaScriptExecutor _javascriptexecutor;

        public IWebDriver Driver
        {
            get { return SiteDriver.Driver; }
        }

        #region Constructor

        public HomePage(string url)
        {
            SiteDriver.Start(url);
        }

        #endregion

        #region Public Methods

        public void SelectBlackColor() =>
            JavascriptExecutor.FindElement(HomePageObjects.BlackColorFilterCssSelector).Click();

        public void ClickFilterButton() =>
            SiteDriver.FindElement(HomePageObjects.FilterButtonCssSelector, How.CssSelector).Click();

        public void ClickAppliAirXNight() =>
            SiteDriver.FindElement(HomePageObjects.AppliAirXNightCssSelector, How.CssSelector).Click();
            
        
        #endregion
    }
}
