using System;
using Xunit;

namespace csharp_koans
{

    public class RecordTypes
    {
        [Fact]
        public void RecordBehavesLikeValueTypes()
        {
            // Records are immutables.
            // Equality is based on properties
            var aDuck = new Duck("Bob", 35);
            var anotherDuck = new Duck("Bob", 35);

            // Correct the assertion
            Assert.False(Object.Equals(aDuck, anotherDuck));
        }

        [Fact]
        public void RecordSupportInheritance()
        {
            // Object type is part of the Equality check.
            var aNewBornDuck = new Duck("Bob", 0);
            var anotherNewBornDuck = new NewBornDuck("Bob");

            // Correct the assertion
            Assert.True(Object.Equals(aNewBornDuck, anotherNewBornDuck));
        }

        [Fact]
        public void RecordCanBeClonedUsingWithKeyword()
        {
            // Record can be clone using the new with keyword
            var aDuck = new Duck("Bob", 35);
            var anotherDuck = aDuck with { };

            // Correct the assertion
            Assert.False(Object.Equals(aDuck, anotherDuck));
        }

        [Fact]
        public void RecordCanBeCloneAndInitialised()
        {
            // Record can be created using the new with keyword.
            // Properties can be set only at initialization, thanks to init keyword.
            var aDuck = new Duck("Bob", 35);
            var anotherDuck = aDuck with { Name = "Dylan" };

            // Correct the assertion
            Assert.True(anotherDuck.Age == 35);
            Assert.True(anotherDuck.Name == "Bob");
        }

        [Fact]
        public void PositionalRecordHaveCompilerGeneratedDeconstructMethod()
        {
            // Record can be declared in a more concise way.
            var aProduct = new Product(12, "Webcam", 12.5m);

            var (id, _, priceVariable) = aProduct;

            // Fix the assertion
            Assert.Equal(13, id);
            Assert.Equal(12.6m, priceVariable);
        }
    }

    public record Duck
    {
        public string Name { get; init; }

        public int Age { get; init; }

        public Duck(string name, int age) => (Age,Name) = (age,name);
    }

    public sealed record NewBornDuck(string name) : Duck(name, 0);

    public record Product(int id, string name, decimal price);

}
