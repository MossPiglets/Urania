using System;
using FluentAssertions;
using NUnit.Framework;
using Urania.Core;

namespace Urania.Tests {
    public class IdCalculatorTests {
        [Test]
        public void Calculate_AllArgumentsAreDecimals_ShouldReturnDecimal() {
            //Arrange
            var ar = 5.31M;
            var wd = 6.99M;
            var od = 51.0969M;
            var expectedResult = ar * wd;
            
            //Act
            var result = IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        public void Calculate_OdIsNull_ShouldReturnDecimal() {
            //Arrange
            var ar = 5.31M;
            var wd = 6.99M;
            decimal? od = null;
            var expectedResult = ar * wd;

            //Act
            var result = IdCalculator.Calculate(ar, wd, od);

            //Assert
            result.Should().Be(expectedResult);
        }
        [Test]
        public void Calculate_WdIsNull_ShouldReturnDecimal() {
            //Arrange
            var ar = 5.31M;
            decimal? wd = null;
            var od = 51.0969M;
            var expectedResult = ar * od / (2 + ar);

            //Act
            var result = IdCalculator.Calculate(ar, wd, od);

            //Assert
            result.Should().Be(expectedResult);
        }
        [Test]
        public void Calculate_ArIsNull_ShouldReturnDecimal() {
            //Arrange
            decimal? ar = null;
            var wd = 6.99M;
            var od = 51.0969M;
            var expectedResult = od - 2 * wd;
            
            //Act
            var result = IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            result.Should().Be(expectedResult);
        }
        [Test]
        public void Calculate_ArAndWdAreNulls_ShouldThrowArgumentNullException() {
            //Arrange
            decimal? ar = null;
            decimal? wd = null;
            var od = 51.0969M;
            
            //Act
            Action act = () => IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            act.Should().Throw<ArgumentNullException>
                (string.Empty, $"Values: {nameof(ar)} = {ar}, {nameof(wd)} = {wd}, {nameof(od)} = {od}");
        }
        [Test]
        public void Calculate_ArAndOdAreNulls_ShouldThrowArgumentNullException() {
            //Arrange
            decimal? ar = null;
            decimal? wd = 6.99M;
            decimal? od = null;
            
            //Act
            Action act = () => IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            act.Should().Throw<ArgumentNullException>
                (string.Empty, $"Values: {nameof(ar)} = {ar}, {nameof(wd)} = {wd}, {nameof(od)} = {od}");
        }
        [Test]
        public void Calculate_OdAndWdAreNulls_ShouldThrowArgumentNullException() {
            //Arrange
            decimal? ar = 5.31M;
            decimal? wd = null;
            decimal? od = null;
            
            //Act
            Action act = () => IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            act.Should().Throw<ArgumentNullException>
                (string.Empty, $"Values: {nameof(ar)} = {ar}, {nameof(wd)} = {wd}, {nameof(od)} = {od}");
        }
        [Test]
        public void Calculate_AllArgumentsAreNulls_ShouldThrowArgumentNullException() {
            //Arrange
            decimal? ar = null;
            decimal? wd = null;
            decimal? od = null;
            
            //Act
            Action act = () => IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            act.Should().Throw<ArgumentNullException>
                (string.Empty, $"Values: {nameof(ar)} = {ar}, {nameof(wd)} = {wd}, {nameof(od)} = {od}");
        }
        [Test]
        public void Calculate_ArIsLessThanZero_ShouldThrowArgumentOutOfRangeException() {
            //Arrange
            var ar = -1M;
            var wd = 6.99M;
            var od = 51.0969M;

            //Act
            Action act = () => IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>(nameof(ar), ar, $"{nameof(ar)} cannot be less than 0");
        }
        [Test]
        public void Calculate_WdIsLessThanZero_ShouldThrowArgumentOutOfRangeException() {
            //Arrange
            var ar = 1M;
            var wd = -6.99M;
            var od = 51.0969M;

            //Act
            Action act = () => IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>(nameof(wd), wd, $"{nameof(wd)} cannot be less than 0");
        }
        [Test]
        public void Calculate_OdIsLessThanZero_ShouldThrowArgumentOutOfRangeException() {
            //Arrange
            var ar = 1M;
            var wd = 6.99M;
            var od = -51.0969M;

            //Act
            Action act = () => IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>(nameof(od), od, $"{nameof(od)} cannot be less than 0");
        }
        [Test]
        public void Calculate_OdTwiceLessThanWdAndArIsNull_ShouldThrowArgumentOutOfRangeException() {
            //Arrange
            decimal? ar = null;
            var wd = 6M;
            var od = 1.0969M;

            //Act
            Action act = () => IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>(nameof(od), od,
                $"{nameof(od)} cannot be twice as small as {nameof(wd)}");
        }
    }
}