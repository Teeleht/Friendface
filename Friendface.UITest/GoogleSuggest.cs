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

                Console.WriteLine("Page title is: " + driver.Title);
            }
            */
            // Login

            using (IWebDriver driver = new FirefoxDriver(service))
            {
                driver.Navigate().GoToUrl("http://friendface.azurewebsites.net");
                driver.FindElement(By.LinkText("Login")).Click();

                var usernameTextBox = driver.FindElement(By.Name("Username"));
                usernameTextBox.Clear();
                usernameTextBox.SendKeys("Teele");

                var passwordTextBox = driver.FindElement(By.Name("Password"));
                passwordTextBox.Clear();
                passwordTextBox.SendKeys("111");

                driver.FindElement(By.XPath("//button[.='Login']")).Click();
                //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);

                IWebElement ClickAndWaitForPageToLoad(By element)
                {
                    try
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        return wait.Until(ExpectedConditions.ElementExists(element));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error occured when trying to login");
                        throw;
                    }
                }

                ClickAndWaitForPageToLoad(By.LinkText("Logout"));




                // birthdays
                /*
                using (IWebDriver driver = new FirefoxDriver(service))
                {
                    driver.Navigate().GoToUrl("http://friendface.azurewebsites.net");

                    //IWebElement signInButton = driver.FindElement(By.TagName("button"));

                    var signInButton = driver.FindElement(By.LinkText("Sign up"));
                    signInButton.Click();

                    var birthdayTextBox = driver.FindElement(By.Name("Birthday"));

                    string y = "";
                    string m = "";
                    string d = "";

                    for (int i = 1; i <= 31; i++)
                    {
                        for (int j = 1; j <= 12; j++)
                        {
                            for (int k = 1999; k <= 2018; k++)
                            {
                                if (i < 10 || j < 10)
                                {
                                    if (i < 10)
                                    {
                                        d = "0" + i.ToString();
                                    }
                                    if (j < 10)
                                    {
                                        m = "0" + j.ToString();
                                    }
                                }
                                else
                                {
                                    d = i.ToString();
                                    m = j.ToString();
                                }
                                y = k.ToString();

                                birthdayTextBox.Clear();
                                birthdayTextBox.SendKeys(y + "-" + m + "-" + d);

                            }
                        }
                    }
                }*/
            }
        }
    }
}
