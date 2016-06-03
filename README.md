# mycucumber
Cucumber/Gherkin-style unit testing support library for .NET - Have you seen my cucumber?

## WTF?
Yes indeed. 

MyCucumber is a test support library for creating BDD-style test definitions that look very
similar to the Gherkin language, championed by Cucumber for Ruby. It allows you to write
tests in this manner whilst being completely agnostic to the unit test framework you are using.

I however am not unit test framework agnostic, therefore all my examples are written to work
with MSTest. If you don't like it, then tough tyres my friend.

## What is Gherkin/Cucumber?
Right, let me Google that for you.

## How do I use it?
There are a number of different implementations (as we are indeed all individual snowflakes),
so to avoid anyone feeling left out, check out the overloads on `.Using` for more info.

Below is just one method for using MyCucumber. Notice how all the arguments wrapped
in curly braces are passed automatically into to your delegate converted to the correct
type - Enums, human booleans and anything that supports `IConvertible`. You're most welcome.

```csharp
[TestClass]
public class KeepItInFamilyTests
{
  [TestMethod]
  public void TomsLargeCucumberShouldImpress_SingleClass()
  {
      new Feature("Feature1", 
          "My feature description goes here and waffles lots and lots.")
      .Given("{tom} has a {large} cucumber")
      .And("{annette} {is} wearing her glasses")
      .When("tom shows annette his cucumber")
      .Then("she should say {oh my!}")
      .Using(this);
  }

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
```

Eventually, I'd like to separate the implementation code into sections
so they can be isolated to just their single responsibility however,
I'm still working on the best way to do this.

## How do I get my hands on MyCucumber?
What you do in your own time is your business.

## Is it on NuGet
By the time you read this, yes it should be. Unless I'm busy or have been abducted
by one of the other teams writing BDD test support libraries.

## Why use this over NSpec/SpecFlow/AnOther..
That's for you to decide, whatever your rational or irrational consciousness 
tells you is best. For me SpecFlow seemed too much (creating config files, MSBuild targets, yada yada) 
and NSpec wasn't close enough to the Gherkin language and used lambda functions unnecessarily
which made things harder to read.