using System;
using Xunit;

namespace csharp_koans
{
    // Nice tutorial about pattern matching using C# 7, 8 and 9
    // https://docs.microsoft.com/fr-fr/dotnet/csharp/tutorials/pattern-matching
    [Trait("Koans", "2")]
    public class PatternMatching
    {
        [Fact]
        public void SwitchWayMoreConcise()
        {
            // Switch statement with new syntax.
            // https://docs.microsoft.com/fr-fr/dotnet/csharp/whats-new/csharp-8#switch-expressions
            var (lattitude, longitude) = GetCoordonates(Capital.Paris);

            // Fix the assertion
            Assert.Equal(1, lattitude);
            Assert.Equal(2, longitude);
        }

        public static Coordonates GetCoordonates(Capital capital) =>
            capital switch
            {
                Capital.Paris => new Coordonates(1, 3),
                Capital.Washington => new Coordonates(1, 4),
                Capital.Pekin => new Coordonates(1, 5),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(Capital))
            };

        [Fact]
        public void PatternMatchingWithPositionnalParameters()
        {
            // Switch can have complex case expression using when keyword
            // https://docs.microsoft.com/fr-fr/dotnet/csharp/whats-new/csharp-8#positional-patterns
            var france = new Country("France", Capital.Paris, 7000000);

            var size = GetSizeOfCountry(france);

            // Fix the assertion
            Assert.Equal("Tiny", size);
        }

        private string GetSizeOfCountry(Country country) =>
            country switch
            {
                var (_, _, population) when population < 1000000 => "Tiny",
                var (_, _, population) when population > 1000000 => "Big",
                _ => "Unknown"
            };


        [Fact]
        public void PatternMatchingWithLogicalPattenrs()
        {
            var france = new Country("Groland", Capital.Groville, 3);

            var size = GetSizeOfCountryOtherWay(france);

            // Fix the assertion
            Assert.Equal("Tiny", size);
        }

        private string GetSizeOfCountryOtherWay(Country country) =>
            country.population switch
            {
                0 => "Really ?",
                1 or 2 or 3 => "No way, cannot exist !",
                > 3 and < 1000000 => "Tiny",
                > 1000000 => "Big",
                _ => "Unknown"
            };


        [Fact]
        public void PatternMatchingOnProperty()
        {
            // Constant value of property can be used in switch
            // https://docs.microsoft.com/fr-fr/dotnet/csharp/whats-new/csharp-8#property-patterns
            var france = new Country("France", Capital.Paris, 7000000);

            var franceIsInOms = isInOMS(france);

            // Fix the assertion
            Assert.False(franceIsInOms);
        }

        private bool isInOMS(Country country) =>
            country switch
            {
                { name: "France" or "China" } => true,
                { name: "USA" } => false,
                _ => false
            };

        [Fact]
        public void PatternMatchingOnObjectTypeAndWhenCondition()
        {
            // Switch can be perform on type.
            // Switch can be perform with a when condition
            // https://docs.microsoft.com/fr-fr/dotnet/csharp/pattern-matching#using-pattern-matching-switch-statements
            var france = new FakeCountry("Groland", Capital.Groville, 5);

            var groland = Display(france);

            // Fix the assertion
            Assert.Equal("is a real country", groland);
        }

        private string Display(Country country) =>
                    country switch
                    {
                        FakeCountry => "is a fake country",
                        Country c when c.population <= 10 => "is probably fake country",
                        Country => "is a real country !",
                        _ => "is unknown"
                    };

        [Fact]
        public void PatternMatchingWithIsAndOrKeywords()
        {
            int? result = null;

            var isNotNull = result is not null;

            // Fix the assertion
            Assert.False(!isNotNull);

            bool isLetterOrExclamation(char c) => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '!';

            // Fix the assertion
            Assert.True(isLetterOrExclamation('?'));

        }

        public record Country(string name, Capital capital, int population);

        public record FakeCountry(string name, Capital capital, int population) : Country(name, capital, population);

        public enum Capital
        {
            Paris,
            Washington,
            Pekin,
            Groville,
        }

        public record Coordonates(decimal lattitude, decimal longitude);
    }


}
