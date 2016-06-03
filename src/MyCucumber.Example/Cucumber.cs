using System;

namespace MyCucumber.Example
{
    public sealed class Cucumber
    {
        public Cucumber(EuropeanApprovedCucumberSize size)
        {
            this.Size = size;
        }

        public EuropeanApprovedCucumberSize Size
        {
            get;
            set;
        }
    }

    public enum EuropeanApprovedCucumberSize
    {
        Small,
        Medium,
        Large
    }

    public sealed class Person
    {
        private string name;
        public Person(string name)
        {
            this.name = name;
        }

        public bool IsWearingGlasses { get; set; }
        public Cucumber Cucumber { get; set; }
        public string SeeCucumber(Person fromPerson)
        {
            if (fromPerson.Cucumber == null) return "what cucumber?";

            switch (fromPerson.Cucumber.Size)
            {
                case EuropeanApprovedCucumberSize.Small:
                    return "are you kidding me?";
                case EuropeanApprovedCucumberSize.Medium:
                    return "that's not impressive";
                case EuropeanApprovedCucumberSize.Large:
                    return "oh my!";
            }

            throw new ArgumentOutOfRangeException("that size is not approved by the european union and should not be allowed!");
        }
    }

    public enum CucumberSize
    {
        Small,
        Medium,
        Large
    }
}
