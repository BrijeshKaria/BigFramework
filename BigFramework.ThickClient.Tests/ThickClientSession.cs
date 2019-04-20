using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Appium;

namespace BigFramework.ThickClient.Tests
{
    [Binding]
    public class ThickClientSession
    {
        protected const string WinAppDriverURI = "http://127.0.0.1:4723";
        //private const string thickClientAppID = @"C:\Users\Administrator\Documents\visual studio 2015\Projects\BigFramework\BigFramework.ThickClient\bin\x86\Debug\BigFramework.ThickClient.exe";
        private const string thickClientAppID = @"E:\SamplePrograms\githubcode\BigFramework\BigFramework.ThickClient\bin\x86\Debug\BigFramework.ThickClient.exe";
        protected static WindowsDriver<AppiumWebElement> session;
        protected static AppiumWebElement FirstName;

        [BeforeTestRun]
        public static void Setup()
        {
            Setup(null);
        }

        public static void Setup(TestContext context)
        {
            // Launch a new instance of Notepad application
            if (session == null)
            {
                // Create a new session to launch Notepad application
                DesiredCapabilities appCapabilities = new DesiredCapabilities();
                //app = Path of your WPF application.
                appCapabilities.SetCapability("app", thickClientAppID);
                //WinAppDriverURI runs here  http://127.0.0.1:4723
                session = new WindowsDriver<AppiumWebElement>(new Uri(WinAppDriverURI), appCapabilities);
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

        [AfterTestRun]
        public static void TearDown()
        {
            // Close the application and delete the session
            if (session != null)
            {
                session.Close();

                try
                {
                    // Dismiss Save dialog if it is blocking the exit
                    //session.FindElementByName("Don't Save").Click();
                }
                catch { }

                session.Quit();
                session = null;
            }
        }

    }
}
