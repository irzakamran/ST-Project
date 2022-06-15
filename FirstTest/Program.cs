// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
// using NUnit.Framework;

// from selenium.WebDriver.common.keys import Keys

namespace ST_Proj_Selenium
{
    [TestClass]
    class AmazonTest : ChromeDriverClass {

        static void Main(string[] args)
        {
            // var base_url="https://www.amazon.com";
            // FirefoxBinary binary = new FirefoxBinary();
            ChromeDriverClass chromeDriver  = new ChromeDriverClass();
            // chromeDriver.ChromeDriverClassInit();
            // IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();

            // IWebElement searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
            // searchBox.SendKeys(search_term);
            // searchBox.Submit();
            var search_term = "iPhone 13";
            searchByName(search_term);
            selectItemFromList("(//div[@class='sg-col-inner']//img[contains(@data-image-latency,'s-product-image')])[2]");
            addToCart();
            Assert.IsTrue(driver.FindElement(By.Id("add-to-cart-confirmation-image")).Displayed);
            // driver.FindElement(By.XPath(
                // "(//div[@class='sg-col-inner']//img[contains(@data-image-latency,'s-product-image')])[2]")).Click();
            // driver.SwitchTo().Window(driver.WindowHandles[1]);
            // .window(driver.window_handles[1]);
            // driver.FindElement(By.Id("add-to-cart-button-ubb")).Click();
            // var className = "a-icon a-icon-alert";

            // # to verify that sub cart page has loaded
            // Assert.AreEqual("Added to Cart", driver.FindElement(By.Id("add-to-cart-confirmation-image")).Text);
            var search_term_2 = "iphone";
            searchByName(search_term_2);
            // IWebElement searchBox2 = driver.FindElement(By.Id("twotabsearchtextbox"));
            // searchBox2.SendKeys(search_term_2);
            // searchBox2.Submit();
            // driver.FindElement(By.Id("add-to-cart-button-ubb")).Click();

            // # to verify that the product was added to the cart successfully
            //assertTrue(driver.FindElement(By.Id("hlb-ptc-btn-native").is_displayed());
            // driver.Quit();
        }

        public static void searchByName (string name) {
            IWebElement searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
            searchBox.SendKeys(name);
            searchBox.Submit();
        }
        public static void addToCart () {
            // driver.FindElement(By.XPath(XPath)).Click();
            driver.FindElement(By.Id("add-to-cart-button")).Click();
        }
        public static void selectItemFromList (string XPath) {
            driver.FindElement(By.XPath(XPath)).Click();
        }
    }
}

public class ChromeDriverClass {    
    public static IWebDriver driver;
    public ChromeDriverClass() {
        var myDriver = new ChromeDriver();
        driver = new ChromeDriver();
    }

    // IWebDriver driver = new ChromeDriver();

}