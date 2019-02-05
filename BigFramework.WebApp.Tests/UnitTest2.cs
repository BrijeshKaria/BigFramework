using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace BigFramework.WebApp.Tests
{
    [TestFixture("chrome", "60", "Windows 10", "WindowsPC", "")]
    public class SauceNUnit_Test
    {
        private RemoteWebDriver driver;
        private String browser;
        private String version;
        private String os;
        private String deviceName;
        private String deviceOrientation;

        public SauceNUnit_Test(String browser, String version, String os, String deviceName, String deviceOrientation)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
            this.deviceName = deviceName;
            this.deviceOrientation = deviceOrientation;
        }

        [SetUp]
        public void Init()
        {
            RemoteWebDriver driver = new ChromeDriver(@"C:\Users\Administrator\Downloads\chromedriver_win32");
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));

            driver.Url = "https://www.bing.com/";
            RemoteWebElement element = (RemoteWebElement)driver.FindElementById("sb_form_q");
            element.SendKeys("webdriver");
            element.SendKeys(Keys.Enter);

            Thread.Sleep(5000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(x => x.Title.Contains("webdriver"));


            //DesiredCapabilities caps = DesiredCapabilities.Chrome();
            //caps.SetCapability(CapabilityType.BrowserName, "chrome");
            //caps.SetCapability(CapabilityType.Version, "60");
            //caps.SetCapability(CapabilityType.Platform, "Windows 10");
            //caps.SetCapability("platformName", "Windows");
            ////caps.SetCapability("app", @"C:\Users\Administrator\Downloads\chromedriver_win32\Chromedriver.exe");
            //caps.SetCapability("app", @"Chrome");
            //caps.SetCapability("deviceName", "WindowsPC");

            //driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4725/wd/hub"), caps, TimeSpan.FromSeconds(60));
            //driver.Url = "https://www.bing.com/";
            //((IWebDriver)driver).Navigate().GoToUrl("https://www.bing.com/");
            //RemoteWebElement element = (RemoteWebElement)driver.FindElementById("sb_form_q");
            //element.SendKeys("webdriver");
            //element.SendKeys(Keys.Enter);

            //Thread.Sleep(5000);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            //wait.Until(x => x.Title.Contains("webdriver"));



        }

        [Test]
        public void googleTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            StringAssert.Contains("Google", driver.Title);
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Sauce Labs");
            query.Submit();
        }

        [TearDown]
        public void CleanUp()
        {
            //var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            //((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            driver?.Quit();
        }
    }
}
