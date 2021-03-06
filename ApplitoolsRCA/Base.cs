﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Applitools;
using Applitools.Selenium;
using Applitools.VisualGrid;
using ApplitoolsRCA;
using ApplitoolsRCA.PageServices;
using NUnit.Framework;
using Configuration = Applitools.Selenium.Configuration;

namespace ApplitoolsRCA
{
    public class Base
    {
        public Eyes _eyes;
        public HomePage homePage;
        public VisualGridRunner runner;
        public Configuration config;
        
        [SetUp]
        public void Initialize()
        {
            //Initialize the Runner for your test.
            runner = new VisualGridRunner(10);

            // Initialize the eyes SDK 
            _eyes = new Eyes(runner);
            
            // Initialize eyes Configuration
            config = new Configuration();
            config.SetApiKey("AS876OwEVY3qDFEAlB4NERfld2wrXCbSDVxewhHgn5E110");
            config.SetBatch(new BatchInfo("Holiday Shopping"));
            config.AddBrowser(1200, 800, BrowserType.CHROME);

            // Add browsers with different viewports
            //Uncomment these to run in multiple browsers
            //config.AddBrowser(1200, 800, BrowserType.FIREFOX);
            //config.AddBrowser(1200, 800, BrowserType.EDGE_CHROMIUM);
            //config.AddBrowser(1200, 800, BrowserType.SAFARI);
            //config.AddDeviceEmulation(DeviceName.iPhone_X);

            _eyes.SetConfiguration(config);

        }

        [TearDown]
        public void TestCleanUp()
        {
            _eyes.CloseAsync();
            SiteDriver.Close();
            TestResultsSummary allTestResults = runner.GetAllTestResults();
            Console.WriteLine(allTestResults);
        }
    }
}
