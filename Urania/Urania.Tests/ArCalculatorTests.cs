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
			var expectedResult = id / wd;

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
			var expectedResult = (od - 2 * wd) / wd;

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
			var expectedResult = id / ((od - id) / 2);

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
			var expectedResult = id / wd;

			//Act
			var result = ArCalculator.Calculate(id, wd, null);

			//Assert
			result.Should().Be(expectedResult);
		}

		[Test]
		public void Calculate_IdAndWdAreNulls_ShouldThrowArgumentNullException() {
			//Arrange
			decimal? id = null;
			decimal? wd = null;
			var od = 34.03M;

			//Act
			Action act = () => ArCalculator.Calculate(null, null, od);

			//Assert
			act.Should().Throw<ArgumentNullException>
				(string.Empty, $"Values: Id == {id}, Wd == {wd}, Od == {od}");
		}

		[Test]
		public void Calculate_IdAndOdAreNulls_ShouldThrowArgumentNullException() {
			//Arrange
			decimal? id = null;
			decimal? od = null;
			var wd = 13.13M;

			//Act
			Action act = () => ArCalculator.Calculate(null, wd, null);

			//Assert
			act.Should().Throw<ArgumentNullException>
				(string.Empty, $"Values: Id == {id}, Wd == {wd}, Od == {od}");
		}

		[Test]
		public void Calculate_OdAndWdAreNulls_ShouldThrowArgumentNullException() {
			//Arrange
			decimal? od = null;
			decimal? wd = null;
			var id = 7.77M;

			//Act
			Action act = () => ArCalculator.Calculate(id, null, null);

			//Assert
			act.Should().Throw<ArgumentNullException>
				(string.Empty, $"Values: Id == {id}, Wd == {wd}, Od == {od}");
		}

		[Test]
		public void Calculate_AllArgumentsAreNulls_ShouldThrowArgumentNullException() {
			//Arrange
			decimal? od = null;
			decimal? wd = null;
			decimal? id = null;
			//Act
			Action act = () => ArCalculator.Calculate(null, null, null);

			//Assert
			act.Should().Throw<ArgumentNullException>
				(string.Empty, $"Values: Id == {id}, Wd == {wd}, Od == {od}");
		}
		[Test]
		public void Calculate_WdIsEqualZeroIdIsEqualNull_ShouldThrowDivideByZeroException() {
			//Arrange
			decimal? od = 34.03M;
			decimal? wd = 0M;
			decimal? id = null;
			//Act
			Action act = () => ArCalculator.Calculate(id, wd, od);

			//Assert
			act.Should().Throw<DivideByZeroException>($"{nameof(wd)} cannot be 0");
		}
		[Test]
		public void Calculate_WdIsEqualZeroOdIsEqualNull_ShouldThrowDivideByZeroException() {
			//Arrange
			decimal? od = null;
			decimal? wd = 0M;
			decimal? id = 7.77M;
			//Act
			Action act = () => ArCalculator.Calculate(id, wd, od);

			//Assert
			act.Should().Throw<DivideByZeroException>($"{nameof(wd)} cannot be 0");
		}
		[Test]
		public void Calculate_OdEqualIdAndWdIsEqualNull_ShouldThrowDivideByZeroException() {
			//Arrange
			decimal? od = 7.77M;
			decimal? wd = null;
			decimal? id = 7.77M;
			//Act
			Action act = () => ArCalculator.Calculate(id, wd, od);

			//Assert
			act.Should().Throw<DivideByZeroException>($"{nameof(od)} cannot be equal {nameof(id)}");
		}
	}
}