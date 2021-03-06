// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace SignInTests
{
    [TestClass]
    class AmazonTest : BasePageClass {
        static void Main(string[] args)
        {
            BasePageClass basePageClass = new BasePageClass();
            AmazonHomePage homePage = new AmazonHomePage();
            SearchPage searchPage = new SearchPage();
            ProductPage productPage = new ProductPage();
            basePageClass.SeleniumInit();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();
            String validEmail = "k181097@nu.edu.pk";
            String invalidEmail = "1234@nu.edu.pk";
		    String validPassword = "zr,4zwq-VvGG!97";
		    String invalidPassword = "1234567890";

            var searchTerma = "iPhone 13";
            string trim = searchTerma.Replace( " ", "+" );
            Console.WriteLine("trim: " + trim);
            homePage.logInSuccessFullTest(validEmail, validPassword);
            homePage.logInWithInvalidPassword(validEmail, invalidPassword);
            homePage.logInWithInvalidEmail(invalidEmail, validPassword);
            homePage.logInWithInvalidEmailAndPassword(invalidEmail, invalidPassword);
        }
    }
}

[TestClass]
public class AmazonHomePage : BasePageClass  {
    [TestMethod]
    public void logInSuccessFullTest(string email, string password){
        By goToSignInPage = By.XPath("//*[@id=\"nav-link-accountList\"]");
        driver.FindElement(goToSignInPage).Click();
        SignInPage signInPage = new SignInPage();
        signInPage.signIn(email, password);
        Console.WriteLine("logged in");
        Assert.IsTrue(driver.Url.Contains("ref_=nav_ya_signin&"));
        Console.WriteLine("after assertion");
    }

    [TestMethod]
    public void logInWithInvalidPassword(string email, string password){
        By goToSignInPage = By.XPath("//*[@id=\"nav-link-accountList\"]");
        driver.FindElement(goToSignInPage).Click();
        SignInPage signInPage = new SignInPage();
        signInPage.signIn(email, password);
        Console.WriteLine("logged in");
        Assert.IsTrue(driver.Url.Contains("ref_=nav_ya_signin&"));
        Console.WriteLine("after assertion");
    }

    [TestMethod]
    public void logInWithInvalidEmail(string email, string password){
        By goToSignInPage = By.XPath("//*[@id=\"nav-link-accountList\"]");
        driver.FindElement(goToSignInPage).Click();
        SignInPage signInPage = new SignInPage();
        signInPage.signIn(email, password);
        Console.WriteLine("logged in");
        Assert.IsTrue(driver.Url.Contains("ref_=nav_ya_signin&"));
        Console.WriteLine("after assertion");
    }

    [TestMethod]
    public void logInWithInvalidEmailAndPassword(string email, string password){
        By goToSignInPage = By.XPath("//*[@id=\"nav-link-accountList\"]");
        driver.FindElement(goToSignInPage).Click();
        SignInPage signInPage = new SignInPage();
        signInPage.signIn(email, password);
        Console.WriteLine("logged in");
        Assert.IsTrue(driver.Url.Contains("ref_=nav_ya_signin&"));
        Console.WriteLine("after assertion");
    }
    
    public void searchByName (string name) {
        IWebElement searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
        searchBox.SendKeys(name);
        searchBox.Submit();


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
public class SearchPage : BasePageClass{
    public void selectItemFromList (string XPath) {
        driver.FindElement(By.XPath(XPath)).Click();
    }
}
public class BasePageClass {
    public static IWebDriver driver;
    public void SeleniumInit(){
        var myDriver = new ChromeDriver();
        driver = myDriver;
    }
}

public class ProductPage : BasePageClass { 
    public void addToCart () {
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
    public void assertionForAddToCart(){
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