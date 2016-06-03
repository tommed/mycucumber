using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCucumber.Example
{
    [TestClass]
    public class UsingDelegateTests
    {
        [TestMethod]
        public void TomsLargeCucumberShouldImpress()
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
