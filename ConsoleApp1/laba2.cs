using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace laba2
{
    class myTestClass
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C:\\Test\\");
        }
        [Test]
        public void test()
        {
            driver.Url = "https://artlebedev.ru/case/";
            driver.FindElement(By.Id("source")).SendKeys("hello");
            Thread.Sleep(5);
            var input = driver.FindElement(By.Id("source")).GetProperty("value");
            var output = driver.FindElement(By.Id("target")).GetProperty("value");
            Assert.True(input == "hello");
            Assert.True(input == output);
            Assert.True(driver.Title == "Конвертер регистров");
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
