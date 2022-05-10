using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationTemplate.Pages
{
    public class GooglePage : BasePage
    {
        public string inputSearch { get; set; }

        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement InputField { get; set; }

        [FindsBy(How = How.Name, Using = "btnK")]
        public IWebElement SearchButton { get; set; }

        public GooglePage(IWebDriver driver) : base(driver)
        {

        }


        public void fillInputField(string inputSearch)
        {
            this.inputSearch = inputSearch;
            InputField.SendKeys(inputSearch);
        }

        public void clickSearchButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("btnK")));
            SearchButton.Click();
        }

        public void checkResult()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("rso")));

            IWebElement searchResult = driver.FindElement(By.XPath("//h3[contains(text(),'" + inputSearch + "')]"));

            Assert.IsTrue(searchResult.Displayed);
        }

    }
}
