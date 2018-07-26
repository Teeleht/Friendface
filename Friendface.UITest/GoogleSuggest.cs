using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Friendface.UITest
{
    class GoogleSuggest
    {
        static void Main(string[] args)
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\TeeleKaldaru\Downloads\geckodriver-v0.21.0-win64", "geckodriver.exe");
     
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";


            // google search "cheese"
            /*
            using (IWebDriver driver = new FirefoxDriver(service))
            {
                driver.Navigate().GoToUrl("http://www.google.com/");

                IWebElement query = driver.FindElement(By.Name("q"));

                query.SendKeys("Cheese");

                query.Submit();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));

                Console.WriteLine("Page title is: " + driver.Title); */

            using (IWebDriver driver = new FirefoxDriver(service))
            {
                driver.Navigate().GoToUrl("http://friendface.azurewebsites.net");

                IWebElement signInButton = driver.FindElement(By.TagName("button"));
            }

            
        }
    }
}
