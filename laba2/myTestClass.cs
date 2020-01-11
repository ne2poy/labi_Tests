using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace laba2
{
    class myTestClass
    {
        IWebDriver webDriver;



        [SetUp]
        public void startBrowser()
        {
            webDriver = new ChromeDriver("C:\\Test\\chromedriver.exe");

        }

        [Test]
        public void test()
        {
            startBrowser();
            webDriver.Url = "http://yandex.ru/";
            Assert.True(true);
        }

        [TearDown]
        public void CloseBrowser()
        {
            webDriver.Close();
        }


    }
}
