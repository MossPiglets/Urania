using System;

namespace Urania.Core {
    public class IdCalculator {
        public static decimal Calculate(decimal? ar, decimal? wd, decimal? od) {
            if (ar != null && wd != null) {
                return (decimal) (ar * wd);
            }

            if (ar != null && od != null) {
                if (ar == -2) {
                    throw new DivideByZeroException($"{nameof(ar)} cannot be equal -2");
                }
                return (decimal) (ar * od / (2 + ar));
            }

            if (wd != null && od != null) {
                return (decimal) (od - 2 * wd);
            }

            throw new ArgumentNullException
                (string.Empty, $"Values: {nameof(ar)} = {ar}, {nameof(wd)} = {wd}, {nameof(od)} = {od}");
        }
    }
}