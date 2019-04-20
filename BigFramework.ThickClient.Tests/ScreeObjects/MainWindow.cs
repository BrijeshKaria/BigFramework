using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFramework.ThickClient.Tests.ScreeObjects
{
    public class MainWindow
    {
        IWebDriver driver = null;
        WebDriverWait wait = null;
        

        [FindsBy(How = How.Id,Using = "TBFirstName")]
        public WindowsElement FirstName;
        [FindsBy(How = How.Id, Using = "LastName")]
        public WindowsElement LastName;
        [FindsBy(How = How.Id, Using = "FullName")]
        public WindowsElement FullName;

        public MainWindow(IWebDriver session)
        {
            this.driver = session;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
    }
}
