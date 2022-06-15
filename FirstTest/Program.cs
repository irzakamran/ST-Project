// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
// using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

// from selenium.WebDriver.common.keys import Keys

namespace selenium
{
    class Program {
        static void Main(string[] args)
        {
            // var base_url="https://www.amazon.com";
            var search_term="Foundation of Software Testing by Dorothy Graham and Rex Black";
            // FirefoxBinary binary = new FirefoxBinary();
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();
            IWebElement searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
            searchBox.SendKeys(search_term);
            searchBox.Submit();
            driver.FindElement(By.XPath(
                "(//div[@class='sg-col-inner']//img[contains(@data-image-latency,'s-product-image')])[2]")).Click();
            // driver.SwitchTo().Window(driver.WindowHandles[1]);
            // .window(driver.window_handles[1]);
            driver.FindElement(By.Id("add-to-cart-button-ubb")).Click();
            // var className = "a-icon a-icon-alert";

            // # to verify that sub cart page has loaded
            // Assert.AreEqual("Added to Cart", driver.FindElement(By.ClassName(className)).Text);
            // # to verify that the product was added to the cart successfully
            //assertTrue(driver.FindElement(By.Id("hlb-ptc-btn-native").is_displayed());
            // driver.Quit();
        }
    }
}