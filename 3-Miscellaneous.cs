using System;
using System.Collections.Generic;
using Xunit;

namespace csharp_koans
{
    [Trait("Koans", "3")]
    public class Miscellaneous
    {
        [Fact]
        public void NewWithoutExplicitTypeIsAllowed()
        {
            France france = new();

            // Also working with parameters
            Country country = new("China");

            // Fix the assertion
            Assert.IsType<int>(france);
            Assert.Equal("Tokyo", country.name);
        }

        [Fact]
        public void NullCoalescingAssignment()
        {
            // ??= Assign the value only if left-hand operation is null
            List<Country> countries = null;

            (countries ??= new()).Add(new("China"));

            // Fix the assertion
            Assert.True(countries.Count == 0);

            // WTF Code ... Beware, it's also possible to use ??
            int? a = null;
            int? b = null;
            int? c = 42;
            List<int> listOfInt = new();

            listOfInt.Add(a ??= b ??= c ?? 0);

            Assert.Equal(12, listOfInt[0]);
        }

        [Fact]
        public void LocalFunctionCanBeDefined()
        {
            int myValue = 0;

            myValue = MultiplyBy(2, getNewValue());

            int getNewValue() => 42;

            int MultiplyBy(int value, int multiplyBy)
            {
                return value * multiplyBy;
            }

            // Fix the assertion
            Assert.Equal(42, myValue);
        }

        [Fact]
        public void IndicesAndRangeInASequence()
        {
            // https://docs.microsoft.com/fr-fr/dotnet/csharp/whats-new/csharp-8#indices-and-ranges
            var words = new string[]
            {
                "Everything",
                "is",
                "awesome",
                "Everything",
                "is",
                "cool"
            };

            Assert.Equal("FIX ME HERE", words[^1]);
            Assert.Equal("FIX ME HERE", string.Join(' ', words[..3]));

            Range r = 0..4;
            Assert.Equal("FIX ME HERE", string.Join(' ', words[r]));
            Assert.Equal("FIX ME HERE", string.Join(' ', words[^3..^1]));

        }


        public record Country(string name);

        public record France() : Country("France");
    }

}
