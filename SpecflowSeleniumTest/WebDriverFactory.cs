using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using SpecflowSeleniumTest.Configs;

namespace SpecflowSeleniumTest
{
    public static class WebDriverFactory
    {
        public static IWebDriver Create(BrowserConfigurations configs)
        {
            IWebDriver driver;

            ChromeOptions chromeOptions = CreateOptions();
            
            driver = new RemoteWebDriver(
                new Uri($"{configs.SeleniumHubUri}"),
                chromeOptions.ToCapabilities(),
                TimeSpan.FromSeconds(configs.CommandTimeout));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToInt32(30));
            driver.Manage().Window.Maximize();

            return driver;
        }

        private static ChromeOptions CreateOptions()
        {
            ChromeOptions chromeOptions = new();
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddArgument("--disable-extensions");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--enable-automation");
            chromeOptions.AddArgument("--disable-browser-side-navigation");
            chromeOptions.AddArgument("--aggressive-cache-discard");
            chromeOptions.AddArgument("--disable-cache");
            chromeOptions.AddArgument("--disable-application-cache");
            chromeOptions.AddArgument("--disable-offline-load-stale-cache");
            chromeOptions.AddArgument("--disk-cache-size=0");
            chromeOptions.AddArgument("--dns-prefetch-disable");
            chromeOptions.AddArgument("--no-proxy-server");
            chromeOptions.AddArgument("--silent");
            chromeOptions.AddArgument("--incognito");
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--log-level=3");
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;

            return chromeOptions;
        }
    }
}
