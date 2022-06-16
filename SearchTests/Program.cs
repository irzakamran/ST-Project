// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchTests
{
    [TestClass]
    class AmazonTest : BasePageClass {
        static void Main(string[] args)
        {
            BasePageClass basePageClass = new BasePageClass();
            AmazonHomePage homePage = new AmazonHomePage();
            SearchPage searchPage = new SearchPage();
            basePageClass.SeleniumInit();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();
            String validEmail = "k181097@nu.edu.pk";
		    String validPassword = "zr,4zwq-VvGG!97";

            homePage.logInSuccessFullTest(validEmail, validPassword);

            var searchTerma = "iPhone 13";
            homePage.searchByNameSuccessful(searchTerm);
            searchPage.selectItemFromList("(//div[@class='sg-col-inner']//img[contains(@data-image-latency,'s-product-image')])[3]");
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
    public void searchByNameSuccessful (string searchTerm) {
        IWebElement searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
        searchBox.SendKeys(searchTerm);
        searchBox.Submit();
        string expectedSearchTermInURL = searchTerm.Replace( " ", "+" );
        Assert.IsTrue(driver.Url.Contains(expectedSearchTermInURL));
    }   

    [TestMethod]
    public void searchByNameUnsuccessful (string searchTerm) {
        IWebElement searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
        searchBox.SendKeys(searchTerm);
        searchBox.Submit();
        string expectedSearchTermInURL = searchTerm.Replace( " ", "+" );
        Assert.IsFalse(driver.Url.Contains(expectedSearchTermInURL));
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