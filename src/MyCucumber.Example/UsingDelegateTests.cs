using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCucumber.Example
{
    /// <summary>
    /// Example unit test where the implementation of the
    /// test can be delegated out to a separate class. This
    /// class would then live elsewhere, keeping your folder
    /// structure neat and tidy (if you like that kind of thing)
    /// </summary>
    [TestClass]
    public class UsingDelegateTests
    {
        [TestMethod]
        public void TomsLargeCucumberShouldImpress_Delegated()
        {
            new Feature("Feature1", 
                "My feature description goes here and waffles lots and lots.")
            .Given("{tom} has a {large} cucumber")
            .And("{annette} {is} wearing her glasses")
            .When("tom shows annette his cucumber")
            .Then("she should say {oh my!}")
            .Using<CucumberTestImpl>();

            // or .Using(typeof(CucumberTestImpl));
            // or .Using(typeof(CucumberTestImpl), "WhateverMethodYouWant");
            // or .Using<CucumberTestImpl>("WhateverMethodYouWant");
        }

        // this test has been delegated to another class
        // you could then optionally keep your implementation
        // code separate from the gherkin-style method chain 
        // above, especially if you are prone to compulsive
        // class organising
        private sealed class CucumberTestImpl
        {
            public void Do(
                string firstPersonName, 
                EuropeanApprovedCucumberSize sizeOfCucumber, 
                string secondPersonName, 
                bool isWearingGlasses, 
                string secondPersonsResponse)
            {
                // given
                var tom = new Person(firstPersonName) {
                    Cucumber = new Cucumber(sizeOfCucumber)
                };

                // and
                var annette = new Person(secondPersonName);
                annette.IsWearingGlasses = isWearingGlasses;

                // when
                var annettesResponse = annette.SeeCucumber(tom);

                // then
                Assert.AreEqual(secondPersonsResponse, annettesResponse);
            }
        }
    }
}
