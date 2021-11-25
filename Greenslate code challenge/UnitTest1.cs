using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Greenslate_code_challenge
{
    public class Tests
    {
        IWebDriver webDriver;

        [OneTimeSetUp]
        public void StartChrome()
        {
            webDriver = new ChromeDriver(".");
        }

        [Test]
        public void Test1()
        {
            webDriver.Url = "https://demo.opencart.com/";
            Assert.Pass();
        }
        [OneTimeTearDown]
        public void CloseTest()
        {
            webDriver.Close();
        }
    }
}