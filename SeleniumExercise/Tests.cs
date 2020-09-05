using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumExercise
{
    
    [TestClass]
    public class Tests : BaseClass
    {
        [TestMethod]
        public void DemoOptions()
        {
            
            By pageHeading = By.XPath("//h2[text()='angular-busy']");
            By textBoxDelay  = By.Id("delayInput");
            By textBoxMinDuration = By.Id("durationInput");
            By textBoxMessage = By.Id("message");
            By dropdownTemplateUrl = By.Id("template");
            By buttonDemo = By.XPath("//button[text()='Demo']");
            By bySpinningElement = By.CssSelector(".cg-busy.cg-busy-animation.ng-scope.ng-hide");
            By dancingImage = By.XPath("//div[contains(@class,'cg-busy-animation')]//div[contains(@style,'finalfantasy.gif')]");
            //First, click Demo with message &quot;Please Wait...&quot;.  Shows the message &quot;Please
            // Wait...& quot; in the busy indicator
            WaitForElement(driver, pageHeading);
            EnterText(driver, textBoxDelay, "10");
            EnterText(driver, textBoxMinDuration, "10");
            EnterText(driver, textBoxMessage, "Please Wait...");
            SelectByVisibleText(driver, dropdownTemplateUrl, "Standard");
            Click(driver, buttonDemo);
            bool status = WaitForSpinner(driver, "Please Wait...");
            Assert.IsTrue(status, "Please Wait... is displayed in busy indicator");
            WaitForElementInvisible(driver,bySpinningElement);

            //Second, Demo with message &quot;Waiting&quot;.  Shows the message &quot;Waiting.&quot; in the busy indicator
            EnterText(driver, textBoxDelay, "10");
            EnterText(driver, textBoxMinDuration, "10");
            EnterText(driver, textBoxMessage, "Waiting...");
            SelectByVisibleText(driver, dropdownTemplateUrl, "Standard");
            Click(driver, buttonDemo);
            bool status1 = WaitForSpinner(driver, "Waiting...");
            Assert.IsTrue(status1, "Waiting... is displayed in busy indicator");
            WaitForElementInvisible(driver, bySpinningElement);

            //Third, Set Minimum duration to 1000 ms, press Demo, busy spinner with
            //message & quot; Waiting.& quot; shows.
            EnterText(driver, textBoxDelay, "10");
            EnterText(driver, textBoxMinDuration, "1000");
            EnterText(driver, textBoxMessage, "Waiting...");
            SelectByVisibleText(driver, dropdownTemplateUrl, "Standard");
            Click(driver, buttonDemo);
            bool status2 = WaitForSpinner(driver, "Waiting...");
            Assert.IsTrue(status2, "Waiting... is displayed in busy indicator");
            WaitForElementInvisible(driver, bySpinningElement);

            // Switch from Standard, press Demo and then to custom-template.html and press Demo,
            //dancing wizard should show

            EnterText(driver, textBoxDelay, "10");
            EnterText(driver, textBoxMinDuration, "1000");
            EnterText(driver, textBoxMessage, "Waiting...");
            SelectByVisibleText(driver, dropdownTemplateUrl, "custom-template.html");
            Click(driver, buttonDemo);
            bool status3 = WaitForSpinner(driver, "Waiting...");
            bool dancingImageStatus = WaitForElement(driver, dancingImage);
            Assert.IsTrue(dancingImageStatus, "Dancing Wizard is displayed");
            Assert.IsTrue(status3, "Please Wait... is displayed in busy indicator");
            WaitForElementInvisible(driver, bySpinningElement);
        }

        public static void SelectByVisibleText(IWebDriver driver,By locator,string text)
        {
            try
            {
                SelectElement oSelect = new SelectElement(driver.FindElement(locator));
                oSelect.SelectByText(text);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            try
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void Click(IWebDriver driver, By locator)
        {
            try
            {
                WaitForElement(driver, locator);
                Actions act = new Actions(driver);
                act.DoubleClick(driver.FindElement(locator)).Build().Perform();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool WaitForElement(IWebDriver driver, By locator)
        {
            bool status = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
                status = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }

        public static bool WaitForElementInvisible(IWebDriver driver, By locator)
        {
            bool status = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
                status = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }

        public static bool WaitForSpinner(IWebDriver driver, string text)
        {
            bool status = false;
            try
            {
                By element = By.XPath("//div[text()='" + text + "']");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                status = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }

    }


}
