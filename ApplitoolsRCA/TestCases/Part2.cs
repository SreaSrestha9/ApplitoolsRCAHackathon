using System;
using System.Collections.Generic;
using System.Text;
using Applitools.Selenium;
using ApplitoolsRCA.PageServices;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ApplitoolsRCA.TestCases
{
    public class Part2 : Base
    {
        [Test]
        public void MainPageTest()
        {
            homePage = new HomePage(Urls.DevVersion);
            _eyes.Open(homePage.Driver, "AppliFashion", "Test 1");
            _eyes.CheckWindow("main page", true);
        }

        [Test]
        public void FilteredProductGridTest()
        {
            homePage = new HomePage(Urls.DevVersion);
            homePage.SelectBlackColor();
            homePage.ClickFilterButton();
            _eyes.Open(homePage.Driver, "AppliFashion", "Test 2");
            _eyes.CheckRegion(By.Id("product_grid"), "filter by color");
        }

        [Test]
        public void ProductDetailsTest()
        {
            homePage = new HomePage(Urls.DevVersion);
            homePage.ClickAppliAirXNight();
            _eyes.Open(homePage.Driver, "AppliFashion", "Test 3");
            _eyes.CheckWindow("product details", true);
        }
    }
}