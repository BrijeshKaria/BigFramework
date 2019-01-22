﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;

namespace BigFramework.ThickClient.Tests
{
    public class ThickClientSession
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string thickClientAppID = @"C:\Users\Administrator\Documents\visual studio 2015\Projects\BigFramework\BigFramework.ThickClient\bin\Debug\BigFramework.ThickClient.exe";

        protected static WindowsDriver<WindowsElement> session;
        protected static WindowsElement FirstName;


        public static void Setup(TestContext context)
        {
            // Launch a new instance of Notepad application
            if (session == null)
            {
                // Create a new session to launch Notepad application
                DesiredCapabilities appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("app", thickClientAppID);
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
                Assert.IsNotNull(session);
                Assert.IsNotNull(session.SessionId);

                // Verify that Notepad is started with untitled new file
                Assert.AreEqual("MainWindow", session.Title);

                // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                session.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1.5));

                // Keep track of the edit box to be used throughout the session
                //FirstName = session.FindElementByXPath("//TextBox[contains(text(), 'Nirav')]");
                FirstName = session.FindElementByAccessibilityId("TBFirstName");
                Assert.IsNotNull(FirstName);
            }
        }

        public static void TearDown()
        {
            // Close the application and delete the session
            if (session != null)
            {
                session.Close();

                try
                {
                    // Dismiss Save dialog if it is blocking the exit
                    session.FindElementByName("Don't Save").Click();
                }
                catch { }

                session.Quit();
                session = null;
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            // Select all text and delete to clear the edit box
            FirstName.SendKeys(Keys.Control + "a" + Keys.Control);
            FirstName.SendKeys(Keys.Delete);
            Assert.AreEqual(string.Empty, FirstName.Text);
        }
    }
}