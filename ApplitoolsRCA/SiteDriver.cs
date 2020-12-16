using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ApplitoolsRCA
{
    public static class SiteDriver
    {
        private static IWebDriver _driver;

        private static IJavaScriptExecutor _javascriptexecutor;

        public static IWebDriver Driver
        {
            get { return _driver; }
        }

        public static IJavaScriptExecutor JsExecutor
        {
            get { return _driver as IJavaScriptExecutor; }
        }

        public static void Start(string url)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            _javascriptexecutor = (IJavaScriptExecutor)_driver;
        }

        public static void Close()
        {
            _driver.Quit();
        }
        
        internal static IWebElement FindElement(string select, How selector)
        {
            return FindElement(select, selector, _driver);
        }

        
        internal static IWebElement FindElement(string select, How selector, ISearchContext context, int elementTimeOut = 2000)
        {
            switch (selector)
            {
                case How.ClassName:
                    return WaitandReturnElementExists(By.ClassName(select), context, elementTimeOut);
                case How.CssSelector:
                    return WaitandReturnElementExists(By.CssSelector(select), context, elementTimeOut);
                case How.Id:
                    return WaitandReturnElementExists(By.Id(select), context, elementTimeOut);
                case How.LinkText:
                    return WaitandReturnElementExists(By.LinkText(select), context, elementTimeOut);
                case How.Name:
                    return WaitandReturnElementExists(By.Name(select), context, elementTimeOut);
                case How.PartialLinkText:
                    return WaitandReturnElementExists(By.PartialLinkText(select), context, elementTimeOut);
                case How.TagName:
                    return WaitandReturnElementExists(By.TagName(select), context, elementTimeOut);
                case How.XPath:
                    return WaitandReturnElementExists(By.XPath(select), context, elementTimeOut);
            }
            throw new NotSupportedException(string.Format("Selector \"{0}\" is not supported.", selector));
        }

        public static IWebElement WaitandReturnElementExists(By locator, ISearchContext context, int elementTimeOut = 2000)
        {
            if (elementTimeOut == 0)
                return context.FindElement(locator);

            var wait = new WebDriverWait(new SystemClock(), _driver, TimeSpan.FromMilliseconds(2000), TimeSpan.FromMilliseconds(2000));
            IWebElement webElement = null;
            wait.Until(driver =>
            {
                try
                {
                    webElement = context.FindElement(locator);
                    return webElement != null;

                }
                catch (Exception ex)
                {
                    return false;
                }
            });
            return webElement;
        }
    }
}
