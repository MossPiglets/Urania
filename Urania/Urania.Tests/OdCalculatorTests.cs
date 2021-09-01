using System;
using FluentAssertions;
using NUnit.Framework;
using Urania.Core;

namespace Urania.Tests {
    public class OdCalculatorTests {
        [Test]
        public void Calculate_AllArgumentsAreDecimals_ShouldReturnDecimal() {
            //Arrange
            var ar = 5.31M;
            var wd = 9.62M;
            var id = 51.0969M;
            var expectedResult = id + 2 * (id / ar);
            
            //Act
            var result = OdCalculator.Calculate(ar, wd, id);

            //Assert
            result.Should().Be(expectedResult);
        }
        [Test]
        public void Calculate_IdIsNull_ShouldReturnDecimal() {
            //Arrange
            var ar = 5.31M;
            var wd = 9.62M;
            decimal? id = null;
            var expectedResult = wd * (ar + 2);

            //Act
            var result = OdCalculator.Calculate(ar, wd, id);

            //Assert
            result.Should().Be(expectedResult);
        }
        [Test]
        public void Calculate_WdIsNull_ShouldReturnDecimal() {
            //Arrange
            var ar = 5.31M;
            decimal? wd = null;
            var id = 51.0969M;
            var expectedResult = id + 2 * (id / ar);

            //Act
            var result = OdCalculator.Calculate(ar, wd, id);

            //Assert
            result.Should().Be(expectedResult);
        }
        [Test]
        public void Calculate_ArIsNull_ShouldReturnDecimal() {
            //Arrange
            decimal? ar = null;
            var wd = 9.62M;
            var id = 51.0969M;
            var expectedResult = id + 2 * wd;

            //Act
            var result = OdCalculator.Calculate(ar, wd, id);

            //Assert
            result.Should().Be(expectedResult);
        }
        [Test]
        public void Calculate_ArAndWdAreNulls_ShouldThrowArgumentNullException() {
            //Arrange
            decimal? ar = null;
            decimal? wd = null;
            var id = 51.0969M;
            
            //Act
            Action act = () => OdCalculator.Calculate(ar, wd, id);
            
            //Assert
            act.Should().Throw<ArgumentNullException>
                (string.Empty, $"Values: {nameof(ar)} = {ar}, {nameof(wd)} = {wd}, {nameof(id)} = {id}");
        }
        [Test]
        public void Calculate_ArAndIdAreNulls_ShouldThrowArgumentNullException() {
            //Arrange
            decimal? ar = null;
            var wd = 9.62M;
            decimal? id = null;
            
            //Act
            Action act = () => OdCalculator.Calculate(ar, wd, id);
            
            //Assert
            act.Should().Throw<ArgumentNullException>
                (string.Empty, $"Values: {nameof(ar)} = {ar}, {nameof(wd)} = {wd}, {nameof(id)} = {id}");
        }
        [Test]
        public void Calculate_IdAndWdAreNulls_ShouldThrowArgumentNullException() {
            //Arrange
            decimal? ar = 5.31M;
            decimal? wd = null;
            decimal? id = null;
            
            //Act
            Action act = () => OdCalculator.Calculate(ar, wd, id);
            
            //Assert
            act.Should().Throw<ArgumentNullException>
                (string.Empty, $"Values: {nameof(ar)} = {ar}, {nameof(wd)} = {wd}, {nameof(id)} = {id}");
        }
        [Test]
        public void Calculate_AllArgumentsAreNulls_ShouldThrowArgumentNullException() {
            //Arrange
            decimal? ar = null;
            decimal? wd = null;
            decimal? id = null;
            
            //Act
            Action act = () => OdCalculator.Calculate(ar, wd, id);
            
            //Assert
            act.Should().Throw<ArgumentNullException>
                (string.Empty, $"Values: {nameof(ar)} = {ar}, {nameof(wd)} = {wd}, {nameof(id)} = {id}");
        }
        [Test]
        public void Calculate_ArIsEqualZero_ShouldThrowDivideByZeroException() {
            //Arrange
            var ar = 0M;
            var wd = 9.62M;
            var id = 51.0969M;

            //Act
            Action act = () => OdCalculator.Calculate(ar, wd, id);
            
            //Assert
            act.Should().Throw<DivideByZeroException>($"{nameof(ar)} cannot be equal 0");
        }
        [Test]
        public void Calculate_ArIsLessThanZero_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            var ar = -1M;
            var wd = 9.62M;
            var id = 51.0969M;

            //Act
            Action act = () => OdCalculator.Calculate(ar, wd, id);

            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>($"{nameof(ar)} cannot be less than 0");
        }
        [Test]
        public void Calculate_WdIsLessThanZero_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            var ar = 5.31M;
            var wd = -1M;
            var id = 51.0969M;

            //Act
            Action act = () => OdCalculator.Calculate(ar, wd, id);

            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>($"{nameof(wd)} cannot be less than 0");
        }
        [Test]
        public void Calculate_IdIsLessThanZero_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            var ar = 5.31M;
            var wd = 9.62M;
            var id = -1M;

            //Act
            Action act = () => OdCalculator.Calculate(ar, wd, id);

            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>($"{nameof(id)} cannot be less than 0");
        }
    }
}