using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCucumber.Example
{
    /// <summary>
    /// Showcasing the use of the `Background` keyword.
    /// </summary>
    [TestClass]
    public class BackgroundTests
    {
        // define your background here
        private readonly Feature background 
            = new Background()
            .Given("{tom} has a {large} cucumber")
            .And("{annette} {is} wearing her glasses");


        [TestMethod]
        public void TomsLargeCucumberShouldImpress_WithBackground()
        {
            new Feature("Feature1", 
                "My feature description goes here and waffles lots and lots.")
            .WithBackground(background) // <- now incorporate it here
            .When("tom shows annette his cucumber")
            .Then("she should say {oh my!}")
            .Using(this);
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
