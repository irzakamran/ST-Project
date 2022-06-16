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

            var searchTerma = "iPhone 13";
            homePage.searchByNameSuccessful(searchTerm);
            searchPage.selectItemFromList("(//div[@class='sg-col-inner']//img[contains(@data-image-latency,'s-product-image')])[3]");
        }
    }
}

[TestClass]
public class AmazonHomePage : BasePageClass  {
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