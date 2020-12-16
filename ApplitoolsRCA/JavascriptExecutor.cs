using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ApplitoolsRCA
{
    public class JavascriptExecutor
    {

        private const string JQueryScript = "return $('{0}').get(0)";


        public static object ExecuteModern(string script)
        {
            return SiteDriver.JsExecutor.ExecuteScript(script);
        }

        public static IWebElement FindElement(string select)
        {
            return (IWebElement)ExecuteModern(string.Format(JQueryScript, select));
        }



    }
}
