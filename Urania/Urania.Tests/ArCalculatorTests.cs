using System;
using FluentAssertions;
using NUnit.Framework;
using Urania.Core;

namespace Urania.Tests {
	public class ArCalculatorTests {
		[Test]
		public void Calculate_AllArgumentsAreDecimals_ShouldReturnDecimalWithTwoNumbersAfterDot() {
			//Arrange
			var id = 7.77M;
			var wd = 13.13M;
			var od = 34.03M;
			var expectedResult = 0.59M;

			//Act
			var result = ArCalculator.Calculate(id, wd, od);

			//Assert
			result.Should().Be(expectedResult);
		}

		[Test]
		public void Calculate_IdIsNull_ShouldReturnDecimalWithTwoNumbersAfterDot() {
			//Arrange
			var wd = 13.13M;
			var od = 34.03M;
			var expectedResult = 0.59M;

			//Act
			var result = ArCalculator.Calculate(null, wd, od);

			//Assert
			result.Should().Be(expectedResult);
		}

		[Test]
		public void Calculate_WdIsNull_ShouldReturnDecimalWithTwoNumbersAfterDot() {
			//Arrange
			var id = 7.77M;
			var od = 34.03M;
			var expectedResult = 0.59M;

			//Act
			var result = ArCalculator.Calculate(id, null, od);

			//Assert
			result.Should().Be(expectedResult);
		}

		[Test]
		public void Calculate_OdIsNull_ShouldReturnDecimalWithTwoNumbersAfterDot() {
			//Arrange
			var id = 7.77M;
			var wd = 13.13M;
			var expectedResult = 0.59M;

			//Act
			var result = ArCalculator.Calculate(id, wd, null);

			//Assert
			result.Should().Be(expectedResult);
		}

		[Test]
		public void Calculate_IdAndWdAreNulls_ShouldReturnArgumentException() {
			//Arrange
			var od = 34.03M;

			//Act
			Action act = () => ArCalculator.Calculate(null, null, od);

			//Assert
			act.Should().Throw<ArgumentException>("More than one null argument");
		}

		[Test]
		public void Calculate_IdAndOdAreNulls_ShouldReturnArgumentException() {
			//Arrange
			var wd = 13.13M;

			//Act
			Action act = () => ArCalculator.Calculate(null, wd, null);

			//Assert
			act.Should().Throw<ArgumentException>("More than one null argument");
		}

		[Test]
		public void Calculate_OdAndWdAreNulls_ShouldReturnArgumentException() {
			//Arrange
			var id = 7.77M;

			//Act
			Action act = () => ArCalculator.Calculate(id, null, null);

			//Assert
			act.Should().Throw<ArgumentException>("More than one null argument");
		}

		[Test]
		public void Calculate_AllArgumentsAreNulls_ShouldReturnArgumentException() {
			//Arrange
			//Act
			Action act = () => ArCalculator.Calculate(null, null, null);

			//Assert
			act.Should().Throw<ArgumentException>("More than one null argument");
		}
	}
}