using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Urania.Core;

namespace Urania.Tests {
    class WdCalculatorTests {
		[Test]
		public void Calculate_AllArgumentsAreDecimals_ShouldReturnDecimalWithTwoNumbersAfterDot() {
			//Arrange
			var id = 7.77M;
			var ar = 13.13M;
			var od = 34.03M;
			var expectedResult = id / ar;

			//Act
			var result = WdCalculator.Calculate(id, ar, od);

			//Assert
			result.Should().Be(expectedResult);
		}

		[Test]
		public void Calculate_IdIsNull_ShouldReturnDecimalWithTwoNumbersAfterDot() {
			//Arrange
			decimal? id = null;
			var ar = 13.13M;
			var od = 34.03M;
			var expectedResult = od / (ar + 2);

			//Act
			var result = WdCalculator.Calculate(id, ar, od);

			//Assert
			result.Should().Be(expectedResult);
		}

		[Test]
		public void Calculate_ArIsNull_ShouldReturnDecimalWithTwoNumbersAfterDot() {
			//Arrange
			var id = 7.77M;
			var od = 34.03M;
			decimal? ar = null;
			var expectedResult = (od - id) / 2;

			//Act
			var result = WdCalculator.Calculate(id, ar, od);

			//Assert
			result.Should().Be(expectedResult);
		}

		[Test]
		public void Calculate_OdIsNull_ShouldReturnDecimalWithTwoNumbersAfterDot() {
			//Arrange
			var id = 7.77M;
			var ar = 13.13M;
			decimal? od = null;
			var expectedResult = id / ar;

			//Act
			var result = WdCalculator.Calculate(id, ar, od);

			//Assert
			result.Should().Be(expectedResult);
		}

		[Test]
		public void Calculate_IdAndArAreNulls_ShouldThrowArgumentNullException() {
			//Arrange
			decimal? id = null;
			decimal? ar = null;
			var od = 34.03M;

			//Act
			Action act = () => WdCalculator.Calculate(id, ar, od);

			//Assert
			act.Should().Throw<ArgumentNullException>
				(string.Empty, $"Values: {nameof(id)} == {id}, {nameof(ar)} == {ar}, {nameof(od)} == {od}");
		}

		[Test]
		public void Calculate_IdAndOdAreNulls_ShouldThrowArgumentNullException() {
			//Arrange
			decimal? id = null;
			decimal? od = null;
			var ar = 13.13M;

			//Act
			Action act = () => WdCalculator.Calculate(id, ar, od);

			//Assert
			act.Should().Throw<ArgumentNullException>
				(string.Empty, $"Values: {nameof(id)} == {id}, {nameof(ar)} == {ar}, {nameof(od)} == {od}");
		}

		[Test]
		public void Calculate_OdAndArAreNulls_ShouldThrowArgumentNullException() {
			//Arrange
			decimal? od = null;
			decimal? ar = null;
			var id = 7.77M;

			//Act
			Action act = () => WdCalculator.Calculate(id, ar, od);

			//Assert
			act.Should().Throw<ArgumentNullException>
				(string.Empty, $"Values: {nameof(id)} == {id}, {nameof(ar)} == {ar}, {nameof(od)} == {od}");
		}

		[Test]
		public void Calculate_AllArgumentsAreNulls_ShouldThrowArgumentNullException() {
			//Arrange
			decimal? od = null;
			decimal? ar = null;
			decimal? id = null;
			//Act
			Action act = () => WdCalculator.Calculate(id, ar, od);

			//Assert
			act.Should().Throw<ArgumentNullException>
				(string.Empty, $"Values: {nameof(id)} == {id}, {nameof(ar)} == {ar}, {nameof(od)} == {od}");
		}

		[Test]
		public void Calculate_ArIsEqualZeroOdIsEqualNull_ShouldThrowDivideByZeroException() {
			//Arrange
			decimal? od = null;
			decimal? ar = 0M;
			decimal? id = 34.03M;
			//Act
			Action act = () => WdCalculator.Calculate(id, ar, od);

			//Assert
			act.Should().Throw<DivideByZeroException>($"{nameof(ar)} cannot be 0");
		}

		[Test]
		public void Calculate_ArIsEqualMinusTwoAndIdIsNull_ShouldThrowDivideByZeroException() {
			//Arrange
			var ar = -2M;
			decimal? id = null;
			var od = 51.0969M;

			//Act
			Action act = () => WdCalculator.Calculate(id, ar, od);

			//Assert
			act.Should().Throw<DivideByZeroException>($"{nameof(ar)} cannot be equal -2");
		}

		[Test]
		public void Calculate_OdIsLessThanIdAndArIsNull_ShouldThrowArgumentOtOfRangeException() {
			//Arrange
			decimal? ar = null;
			var id = 34.03M;
			var od = 7.77M;

			//Act
			Action act = () => WdCalculator.Calculate(id, ar, od);

			//Assert
			act.Should().Throw<ArgumentOutOfRangeException>($"{nameof(od)} must be greater than {nameof(id)}");
		}

		[Test]
		public void Calculate_OdIsEqualToIdAndArIsNull_ShouldThrowArgumentOtOfRangeException() {
			//Arrange
			decimal? ar = null;
			var id = 51.0969M;
			var od = 51.0969M;

			//Act
			Action act = () => WdCalculator.Calculate(id, ar, od);

			//Assert
			act.Should().Throw<ArgumentOutOfRangeException>($"{nameof(od)} must be greater than {nameof(id)}");
		}
	}
}
