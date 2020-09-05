using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumExercise
{
    [TestClass]
    public class BaseClass
    {
        protected IWebDriver driver = null;
        [TestInitialize]
        public void BrowserInitilize()
        {
            driver = new ChromeDriver(System.IO.Directory.GetCurrentDirectory() + "\\Drivers");
            driver.Navigate().GoToUrl("http://cgross.github.io/angular-busy/demo/");
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Quit();
        }
        
    }
}
