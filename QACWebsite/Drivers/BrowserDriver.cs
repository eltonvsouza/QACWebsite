using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Dynamitey;
using System.Configuration;

namespace QACWebsite.Drivers
{
    internal class BrowserDriver
    {
        private readonly IWebDriver _currentWebDriver;
        public BrowserDriver() => _currentWebDriver = CreateWebDriver();
        public IWebDriver Current => _currentWebDriver;
        private IWebDriver CreateWebDriver()
        {
            /* 
             * Set environment variable for local testing.
             * To make it works in Azure DevOps, you need to go to Pipelines/Library
             * and create a Variable Group and add it to azure-pipelines.yml
             */
            Environment.SetEnvironmentVariable("url", "https://qaconsultants.com");

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
            chromeDriver.Url = Environment.GetEnvironmentVariable("url");
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            return chromeDriver;
        }
    }
}
