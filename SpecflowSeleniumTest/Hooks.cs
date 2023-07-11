using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Remote;
using SpecflowSeleniumTest.Configs;
using TechTalk.SpecFlow;

namespace SpecflowSeleniumTest
{
    public class Hooks
    {
        private readonly IObjectContainer _featureContainer;
        private static BrowserConfigurations? _config;

        public Hooks(FeatureContext featureContext)
        {
            _featureContainer = featureContext.FeatureContainer;

            _config ??= new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build()
                .GetSection("BrowserConfigurations")
                .Get<BrowserConfigurations>(); ;
        }

        [BeforeScenario(Order = 0)]
        public void Bindings()
        {
            var webDriver = WebDriverFactory.Create(_config);
            _featureContainer.RegisterInstanceAs(webDriver);
        }
    }
}
