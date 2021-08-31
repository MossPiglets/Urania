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
            var expectingResult = ar * wd;
            
            //Act
            var result = IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            result.Should().Be(expectingResult);
        }

        [Test]
        public void Calculate_OdIsNull_ShouldReturnDecimal() {
            //Arrange
            var ar = 5.31M;
            var wd = 6.99M;
            decimal? od = null;
            var expectingResult = ar * wd;

            //Act
            var result = IdCalculator.Calculate(ar, wd, od);

            //Assert
            result.Should().Be(expectingResult);
        }
        [Test]
        public void Calculate_WdIsNull_ShouldReturnDecimal() {
            //Arrange
            var ar = 5.31M;
            decimal? wd = null;
            var od = 51.0969M;
            var expectingResult = ar * od / (2 + ar);

            //Act
            var result = IdCalculator.Calculate(ar, wd, od);

            //Assert
            result.Should().Be(expectingResult);
        }
        [Test]
        public void Calculate_ArIsNull_ShouldReturnDecimal() {
            //Arrange
            decimal? ar = null;
            var wd = 6.99M;
            var od = 51.0969M;
            var expectingResult = od - 2 * wd;
            
            //Act
            var result = IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            result.Should().Be(expectingResult);
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
        public void Calculate_ArIsEqualMinusTwoAndWdIsNull_ShouldThrowDivideByZeroException() {
            //Arrange
            var ar = -2M;
            decimal? wd = null;
            var od = 51.0969M;

            //Act
            Action act = () => IdCalculator.Calculate(ar, wd, od);
            
            //Assert
            act.Should().Throw<DivideByZeroException>($"{nameof(ar)} cannot be equal -2");
        }
    }
}