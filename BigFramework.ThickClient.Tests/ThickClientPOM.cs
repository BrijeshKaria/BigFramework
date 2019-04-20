using BigFramework.ThickClient.Tests.ScreeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BigFramework.ThickClient.Tests
{
    [Binding]
    public sealed class ThickClientPOM:ThickClientSession
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
        MainWindow mainwindow;
        public ThickClientPOM()
        {
            mainwindow = new MainWindow(session);
        }


        public ThickClientPOM(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"Update ""(.*)"" into the firstname")]
        public void GivenUpdateIntoTheFirstname(string p0)
        {
            mainwindow = new MainWindow(session);
            mainwindow.FirstName.SendKeys(p0);
        }

        [Given(@"Update ""(.*)"" into the lastname")]
        public void GivenUpdateIntoTheLastname(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the ""(.*)"" is updated")]
        public void ThenTheIsUpdated(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
