using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;

namespace Greenslate_code_challenge
{
    public class Tests
    {
        IWebDriver webDriver;
        //Locators for the 1st scenario
        By myAccountBtn = By.XPath("//span[@class='hidden-xs hidden-sm hidden-md'][text()='My Account']");
        By registerBtn = By.XPath("//a[text()='Register']");
        By nameField = By.XPath("//input[@id='input-firstname']");
        By lastNameField = By.XPath("//input[@id='input-lastname']");
        By emailField = By.XPath("//input[@id='input-email']");
        By telField = By.XPath("//input[@id='input-telephone']");
        By pwdField = By.XPath("//input[@id='input-password']");
        By pwdConfirmField = By.XPath("//input[@id='input-confirm']");
        By submitBtn = By.XPath("//input[@value='Continue']");
        By agreeBox = By.XPath("//input[@name='agree']");
        By messageAccount = By.XPath("//h1[contains(text(),'Your Account Has Been Created!')]");

        //Locators for the 2nd scenario

        By searchField = By.XPath("//input[@name='search']");
        By searchBtn = By.XPath("//button[@class='btn btn-default btn-lg']");
        string productLnk = "//a[text() = '{0}']";
        By addtocartBtn = By.Id("button-cart");
        string messageProductAdded = "//div[contains(text(),'You have added')]/a[text()='{0}']";

        //Locators for the 3rd scenario
        By taxField = By.XPath("//li[contains(text(),\"Ex Tax\")]");
        By currencyBtn = By.XPath("//span[text() = \"Currency\"]");
        By dropdowncurrencyLabel = By.XPath ("//button[@class=\"btn btn-link dropdown-toggle\"]/strong"); 


        [OneTimeSetUp]
        public void StartChrome()
        {
            webDriver = new ChromeDriver(".");
            webDriver.Manage().Window.Maximize();
        }

        public void searchProduct(string product)
        {
            webDriver.FindElement(searchField).Click();
            webDriver.FindElement(searchField).SendKeys(product);
            webDriver.FindElement(searchBtn).Click();
        }

        [Test]
        public void Test3()
        {

            webDriver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            webDriver.Url = "https://demo.opencart.com/";

            string productVar = "iPhone";
            searchProduct(productVar);
            string Xpath = string.Format(productLnk, productVar);
            By productLnkElement = By.XPath(Xpath);
            webDriver.FindElement(productLnkElement).Click();

            string currency = webDriver.FindElement(dropdowncurrencyLabel).Text;
            string currencyTxt = webDriver.FindElement(taxField).GetAttribute("outerHTML");
            Assert.IsTrue(currencyTxt.Contains(currency));

            
            Assert.Pass();

        }
        [Test]
        public void Test2()
        {
            string productVar = "iMac";
            string Xpath = string.Format(messageProductAdded, productVar);
            By messageXpath = By.XPath(Xpath);

            webDriver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            webDriver.Url = "https://demo.opencart.com/";

            searchProduct(productVar);
            Xpath = string.Format(productLnk, productVar);
            By productLnkElement = By.XPath(Xpath);
            webDriver.FindElement(productLnkElement).Click();

            WebDriverWait wait = new WebDriverWait(webDriver, System.TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(addtocartBtn));
            webDriver.FindElement(addtocartBtn).Click();

            Assert.IsTrue(webDriver.FindElement(messageXpath).Displayed);

            Assert.Pass();


        }
        [Test]
        public void Test1()
        {

         webDriver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(20);
        webDriver.Url = "https://demo.opencart.com/";

        webDriver.FindElement(myAccountBtn).Click();
        webDriver.FindElement(registerBtn).Click();
        webDriver.FindElement(nameField).SendKeys("Luis");
         webDriver.FindElement(lastNameField).SendKeys("Rodriguez");
        webDriver.FindElement(emailField).SendKeys("lrod25@lol.com");
        webDriver.FindElement(telField).SendKeys("555555");
        webDriver.FindElement(pwdField).SendKeys("1234");
        webDriver.FindElement(pwdConfirmField).SendKeys("1234");
        webDriver.FindElement(agreeBox).Click();
        webDriver.FindElement(submitBtn).Click();
        Assert.IsTrue(webDriver.FindElement(messageAccount).Displayed);

        Assert.Pass();

        }




}
}
