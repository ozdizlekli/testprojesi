using NUnit.Framework;
using System;
using TermProject2;

namespace TermProject2.Tests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new DemeritPointsCalculator();
        }

        // Test for speeds at or below the speed limit (65 km/h)
        [TestCase(0)]
        [TestCase(30)]
        [TestCase(50)]
        [TestCase(65)]
        public void CalculateDemeritPoints_SpeedAtOrBelowLimit_ReturnsZero(int speed)
        {
            // Act
            var result = _calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        // Test for speeds just above the speed limit
        [TestCase(66, 0)]  // 1 km over, less than 5 km per point
        [TestCase(69, 0)]  // 4 km over, less than 5 km per point
        [TestCase(70, 1)]  // 5 km over, exactly 1 point
        [TestCase(75, 2)]  // 10 km over, 2 points
        public void CalculateDemeritPoints_SpeedAboveLimit_ReturnsCorrectPoints(int speed, int expectedPoints)
        {
            // Act
            var result = _calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.EqualTo(expectedPoints));
        }

        // Test for various valid speeds above limit
        [TestCase(80, 3)]   // 15 km over limit
        [TestCase(100, 7)]  // 35 km over limit
        [TestCase(150, 17)] // 85 km over limit
        [TestCase(200, 27)] // 135 km over limit
        public void CalculateDemeritPoints_VariousSpeedsAboveLimit_ReturnsCorrectPoints(int speed, int expectedPoints)
        {
            // Act
            var result = _calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.EqualTo(expectedPoints));
        }

        // Test boundary at maximum speed
        [Test]
        public void CalculateDemeritPoints_MaximumSpeed_ReturnsCorrectPoints()
        {
            // Arrange
            int maxSpeed = 300;
            int expectedPoints = (300 - 65) / 5; // 47 points

            // Act
            var result = _calculator.CalculateDemeritPoints(maxSpeed);

            // Assert
            Assert.That(result, Is.EqualTo(expectedPoints));
        }

        // Test for negative speed (invalid input)
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void CalculateDemeritPoints_NegativeSpeed_ThrowsArgumentOutOfRangeException(int speed)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                _calculator.CalculateDemeritPoints(speed));
        }

        // Test for speed exceeding maximum (invalid input)
        [TestCase(301)]
        [TestCase(350)]
        [TestCase(1000)]
        public void CalculateDemeritPoints_SpeedAboveMaximum_ThrowsArgumentOutOfRangeException(int speed)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                _calculator.CalculateDemeritPoints(speed));
        }

        // Test exact boundary values
        [Test]
        public void CalculateDemeritPoints_SpeedAtExactLimit_ReturnsZero()
        {
            // Arrange
            int speedLimit = 65;

            // Act
            var result = _calculator.CalculateDemeritPoints(speedLimit);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedOneAboveLimit_ReturnsZero()
        {
            // Arrange
            int speed = 66;

            // Act
            var result = _calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.EqualTo(0)); // (66-65)/5 = 0 (integer division)
        }

        [Test]
        public void CalculateDemeritPoints_ZeroSpeed_ReturnsZero()
        {
            // Act
            var result = _calculator.CalculateDemeritPoints(0);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
