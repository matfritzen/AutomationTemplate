using System;
using AutomationTemplate.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;



namespace AutomationTemplate.Steps
{
    [Binding]
    public class GoogleSteps : GooglePage
    {

        public GoogleSteps(IWebDriver driver) : base(driver)
        {

        }

        [Given("I fill the input field with (.*)")]
        public void GivenIFillTheInputFieldWith(string searchText)
        {
            fillInputField(searchText);
        }

        [When("I click the search button")]
        public void WhenIClickTheSearchButton()
        {
            clickSearchButton();
        }

        [Then("the result should be displayed")]
        public void ThenTheResultShouldBe()
        {
            checkResult();
        }
    }
}
