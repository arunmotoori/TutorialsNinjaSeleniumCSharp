using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TutorialsNinja.Hooks
{
    [Binding]
    public sealed class WebHooks
    {
        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest featureName;
        public static ExtentTest scenarioName;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter("C:\\Users\\arunm\\source\\repos\\TutorialsNinjaSolution\\TutorialsNinja\\index.html");

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
        
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
 
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            scenarioName = extent.CreateTest<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
           
        }

        [AfterStep]
        public static void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
            }else if(ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (stepType == "When")
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message); 
                else if (stepType == "Then")
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);

            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}