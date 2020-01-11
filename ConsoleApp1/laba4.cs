using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace ConsoleApp1
{
    class laba4
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
            string[] searchWords = { "поисковые запросы", "Как продвинуть много видеороликов на Youtube", "SEO компания Link Fish Media" };
            driver.Url = "http://shakin.ru/";

            foreach (string word in searchWords)
            {
                driver.FindElement(By.ClassName("search-form-input")).SendKeys(word);
                driver.FindElement(By.ClassName("search-form-input")).SendKeys(Keys.Return);
                Thread.Sleep(2);
                var title = driver.FindElements(By.CssSelector(".entry-title-link"));
                var body = driver.FindElements(By.CssSelector(".entry-content p"));
                string headStr = "- Заголовок -";
                string bodyStr = "- Тело -";

                Console.WriteLine("Запрос: '{0}', релевантных результатов: {1}", word, body.Count);
                int i = 0;
                foreach (var element in title)
                {
                    Console.WriteLine("Результат №{0}", i+1);
                    Search(word, element, headStr);
                    Search(word, body[i], bodyStr);
                    i++;
                }
                driver.FindElement(By.ClassName("search-form-input")).Clear();
            }
        }

        void Search(string searchWord, IWebElement webElement, string header)
        {
            string[] wordMas = searchWord.Split(' ');
            Console.WriteLine(header);
            foreach (string word in wordMas)
                Console.WriteLine("Слово: '{0}', встретилось:{1} раз", word, SearchTitleName(word, webElement.Text));
        }

        int SearchTitleName(string searchWord, string bodyText)
        {
            var masWords = bodyText.Split(' ');
            int counter = 0;
            foreach (var word in masWords)
                if (word.Contains(searchWord))
                    counter++;
            return counter;
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
