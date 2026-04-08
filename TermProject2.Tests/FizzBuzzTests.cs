using NUnit.Framework;
using TermProject2;

namespace TermProject2.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void Setup()
        {
            _fizzBuzz = new FizzBuzz();
        }

        // Test for numbers divisible by both 3 and 5
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(0)]
        public void GetOutput_NumberDivisibleByBoth3And5_ReturnsFizzBuzz(int number)
        {
            // Act
            var result = _fizzBuzz.GetOutput(number);

            // Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        // Test for numbers divisible by 3 only
        [TestCase(3)]
        [TestCase(9)]
        [TestCase(12)]
        [TestCase(27)]
        public void GetOutput_NumberDivisibleBy3Only_ReturnsFizz(int number)
        {
            // Act
            var result = _fizzBuzz.GetOutput(number);

            // Assert
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        // Test for numbers divisible by 5 only
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(25)]
        public void GetOutput_NumberDivisibleBy5Only_ReturnsBuzz(int number)
        {
            // Act
            var result = _fizzBuzz.GetOutput(number);

            // Assert
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        // Test for numbers not divisible by 3 or 5
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(7)]
        [TestCase(11)]
        public void GetOutput_NumberNotDivisibleBy3Or5_ReturnsNumberAsString(int number)
        {
            // Act
            var result = _fizzBuzz.GetOutput(number);

            // Assert
            Assert.That(result, Is.EqualTo(number.ToString()));
        }

        // Test for negative numbers
        [TestCase(-15)]
        [TestCase(-3)]
        [TestCase(-5)]
        [TestCase(-1)]
        public void GetOutput_NegativeNumbers_ReturnsCorrectOutput(int number)
        {
            // Act
            var result = _fizzBuzz.GetOutput(number);

            // Assert
            if (number % 15 == 0)
                Assert.That(result, Is.EqualTo("FizzBuzz"));
            else if (number % 3 == 0)
                Assert.That(result, Is.EqualTo("Fizz"));
            else if (number % 5 == 0)
                Assert.That(result, Is.EqualTo("Buzz"));
            else
                Assert.That(result, Is.EqualTo(number.ToString()));
        }

        // Test boundary values
        [Test]
        public void GetOutput_Zero_ReturnsFizzBuzz()
        {
            // Act
            var result = _fizzBuzz.GetOutput(0);

            // Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        // Test large numbers
        [TestCase(300)]
        [TestCase(999)]
        [TestCase(1000)]
        public void GetOutput_LargeNumbers_ReturnsCorrectOutput(int number)
        {
            // Act
            var result = _fizzBuzz.GetOutput(number);

            // Assert
            if (number % 15 == 0)
                Assert.That(result, Is.EqualTo("FizzBuzz"));
            else if (number % 3 == 0)
                Assert.That(result, Is.EqualTo("Fizz"));
            else if (number % 5 == 0)
                Assert.That(result, Is.EqualTo("Buzz"));
            else
                Assert.That(result, Is.EqualTo(number.ToString()));
        }
    }
}
