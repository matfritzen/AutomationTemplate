using System;
using AutomationTemplate.Enumerators;
using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;




namespace AutomationTemplate.Hook
{
    [Binding]
    public class Hook
    {

        public IWebDriver driver;
        private string url;
        public Browser browser;
        private readonly IObjectContainer container;

        public Hook(IObjectContainer container)
        {
            this.container = container;
        }

        [Before]
        public void setUp()
        {


            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            //url = configuration.GetSection("Url").GetSection("Default").ToString();
            url = "https://www.google.com.br/";

            switch (browser)
            {

                case Browser.CHROME:

                    ChromeOptions chromeOptions = new ChromeOptions();

                    //chromeOptions.AddArguments("--headless");
                    //chromeOptions.AddArguments("--window-size=1920,1080");

                    driver = new ChromeDriver();

                    break;

                case Browser.MOZILLA:

                    FirefoxOptions firefoxOptions = new FirefoxOptions();

                    //firefoxOptions.AddArguments("--headless");
                    //firefoxOptions.AddArguments("--window-size=1920,1080");

                    driver = new FirefoxDriver();

                    break;

                case Browser.EDGE:
                    EdgeOptions edgeOptions = new EdgeOptions();

                    //edgeOptions.AddArguments("--headless");
                    //edgeOptions.AddArguments("--window-size=1920,1080");

                    driver = new EdgeDriver();

                    break;


                default:
                    driver = new ChromeDriver();
                    break;

            }

            // Maximizing the size of the browser window
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            // Make this instance available to all other step definitions
            container.RegisterInstanceAs(driver);
        }

        [After]
        public void stop(ScenarioContext scenario)
        {

            Console.WriteLine("Scenario title: " + scenario.ScenarioInfo.Title);
            Console.WriteLine("Scenario status: " + scenario.ScenarioExecutionStatus);
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            if (scenario.TestError != null)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile("/Users/matheus.fritzen/Pictures/Image.png",
                ScreenshotImageFormat.Png);
            }

            close();
        }


        public void close()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
