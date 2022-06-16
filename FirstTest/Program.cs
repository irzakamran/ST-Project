// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// using NUnit.Framework;
namespace ST_Proj_Selenium
{
    [TestClass]
    class AmazonTest : BasePageClass {

        [TestMethod]
        static void Main(string[] args)
        {
            BasePageClass basePageClass = new BasePageClass();
            basePageClass.SeleniumInit();
            // ChromeDriverClass chromeDriver  = new ChromeDriverClass();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();
            String email = "k181097@nu.edu.pk";
		    String password = "zr,4zwq-VvGG!97";

            AmazonHomePage homePage = new AmazonHomePage();
            homePage.logIn(email, password);
            // homePage.logIn(email, password);

            var search_term = "iPhone 13";
            searchByName(search_term);
            selectItemFromList("(//div[@class='sg-col-inner']//img[contains(@data-image-latency,'s-product-image')])[3]");
            addToCart();
            driver.Navigate().Back();
            driver.Navigate().Back();
            selectItemFromList("(//div[@class='sg-col-inner']//img[contains(@data-image-latency,'s-product-image')])[5]");
            // driver.FindElement(By.CssSelector("#a-autoid-7-announce > div > div.twisterTextDiv.text > p")).Click();
            // driver.FindElement(By.CssSelector("#a-autoid-10-announce > div > div:nth-child(1) > img")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

            addToCart();
            // var search_term_2 = "iphone charger";
            // selectItemFromList("(//div[@class='sg-col-inner']//img[contains(@data-image-latency,'s-product-image')])[3]");

            // searchByName(search_term_2);
            // driver.Quit();
        }

        // public static void logIn(string email, string password){
    	// 	driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]")).Click();
        // 	driver.FindElement(By.Id("ap_email")).SendKeys(email);     
        // 	driver.FindElement(By.Id("continue")).Click();
        // 	driver.FindElement(By.Id("ap_password")).SendKeys(password);       
        // 	driver.FindElement(By.Id("signInSubmit")).Click();
        //     Console.WriteLine(driver.Url.Contains("ref_=nav_ya_signin&").ToString(), driver.Url);
        //     Assert.IsTrue(driver.Url.Contains("ref_=nav_ya_signin&"));
        //     // ref_=nav_ya_signin&
        //     // Console.WriteLine("this is the text: ",driver.FindElement(By.XPath("//*[@id="nav-link-accountList-nav-line-1\\"]"))).Text);
        //     // Assert.AreEqual("Your Account",driver.FindElement(By.ClassName("nav-title")).Text);
        // }

        public static void searchByName (string name) {
            IWebElement searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
            searchBox.SendKeys(name);
            searchBox.Submit();
        }
        public static void addToCart () {
            driver.FindElement(By.Id("add-to-cart-button")).Click();
            bool present;
            try {
                IWebElement noThanksButton = driver.FindElement(By.CssSelector("#attachSiNoCoverage > span > input"));
                present = true;
                noThanksButton.Click();
            }
            catch (NoSuchElementException e) {
                present = false;
            }
            assertionForAddToCart();
        }
        public static void selectItemFromList (string XPath) {
            driver.FindElement(By.XPath(XPath)).Click();
        }

        public static void assertionForAddToCart(){
            try {
                Assert.IsTrue(driver.FindElement(By.Id("add-to-cart-confirmation-image")).Displayed);
            }
            catch (NoSuchElementException e) {
                Assert.IsTrue(driver.FindElement(By.CssSelector("#sw-atc-details-single-container > div.a-section.a-padding-medium.sw-atc-message-section > div > span")).Displayed);
            }
            catch {
                Assert.Fail();
            }
        }
    }
}

public class AmazonHomePage : BasePageClass  {
    public void logIn(string email, string password){
        By goToSignInPage = By.XPath("//*[@id=\"nav-link-accountList\"]");
        driver.FindElement(goToSignInPage).Click();
        SignInPage signInPage = new SignInPage();
        signInPage.signIn(email, password);
        Console.WriteLine("logged in");
        Assert.IsTrue(driver.Url.Contains("ref_=nav_ya_signin&"));
        Console.WriteLine("after assertion");
    }
}

public class SignInPage : BasePageClass {
    public void signIn(string email, string password){
        By emailTextBox = By.Id("ap_email");
        By continueButton = By.Id("continue");
        By passwordTextBox = By.Id("ap_password"); 
        By signInButton = By.Id("signInSubmit");
        driver.FindElement(By.Id("ap_email")).SendKeys(email);     
        driver.FindElement(continueButton).Click();
        driver.FindElement(passwordTextBox).SendKeys(password);       
        driver.FindElement(signInButton).Click();
    }
}

public class BasePageClass {
    public static IWebDriver driver;
    public void SeleniumInit(){
        var myDriver = new ChromeDriver();
        driver = myDriver;
    }
}