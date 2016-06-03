using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCucumber.Example
{
    [TestClass]
    public class KeepItInFamilyTests
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
            .Using(this);

            // or .Using(this, "WhateverMethodYouWant");
        }

        // notice how this method now lives inside the unttest class
        // and not assigned to a delegate? This is because Using(this)
        // looks for the function Do in the delegate instance you pass it!
        // you could easily rename this method using the overload with the
        // `methodName` parameter.
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
