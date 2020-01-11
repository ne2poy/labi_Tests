using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace ConsoleApp1
{
    class laba3
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
            driver.Url = "https://yandex.ru/";
            var searchWord = "Большой театр";
            driver.FindElement(By.ClassName("input__control")).SendKeys(searchWord);
            driver.FindElement(By.ClassName("input__control")).SendKeys(Keys.Return);
            Thread.Sleep(5);
            Console.WriteLine("Поиск {0} на первых 2-х страницах...", searchWord);
            int mainCounter = 0;
            for (int i = 1; i < 3; i++)
            {
                int onePageCounter = SearchTitleName(searchWord);
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("страниица № {0}, релевантных результатов: {1}", i, onePageCounter);
                Console.WriteLine("-----------------------------------------------------------");

                mainCounter += onePageCounter;
            }
            Console.WriteLine("Всего релевантных результатов: {0}", mainCounter);
        }

        int SearchTitleName(string searchWord)
        {
            var webElements = driver.FindElements(By.CssSelector(".organic__title-wrapper"));

            int counter = 0;
            foreach(var element in webElements)
            {
                Console.WriteLine(element.Text);
                counter++;
            }
            return counter;
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
