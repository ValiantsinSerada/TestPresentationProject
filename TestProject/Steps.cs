using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestProject
{
    [Binding]
    public sealed class Steps
    {
        IWebDriver Driver = new ChromeDriver(new ChromeOptions());
        
        [Given(@"I go to the (.*)")]
        public void GivenIGoToTheHttpsPlnkr_CoEditFSYkSmlJgOaenYT(string url)
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
        }

        [Given(@"Click Run button")]
        public void GivenClickRunButton()
        {
            Driver.FindElement(By.XPath("//div[@class = 'plunker-toolbar btn-toolbar']//div[@class = 'ng-scope']")).Click();
        }

        [When(@"I resize table frame")]
        public void WhenIResizeTableFrame()
        {
            Actions ac = new Actions(Driver);
            IWebElement devider = Driver.FindElement(By.XPath("//div[contains(@class, 'ui-layout-resizer')]"));
            ac.DragAndDropToOffset(devider, -400, 0);
            ac.Build().Perform();
        }

        [Then(@"I can see example table")]
        public void ThenICanSeeExampleTable(Table expectedData)
        {
            Driver.SwitchTo().Frame("plunkerPreviewTarget");
            Driver.WaitUntilVisible(By.XPath("//div[@class = 'div-table-row']"));
            //Arrange
            var expectedTableData = expectedData.CreateSet<TableData>().ToList();
            var actualTableData = Driver.ExtractTableData<TableData>();
            //Assert
            actualTableData.Should().BeEquivalentTo(expectedTableData);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Dispose();
            Driver = null;
        }
    }
}
