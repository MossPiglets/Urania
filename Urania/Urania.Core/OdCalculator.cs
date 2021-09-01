using System;

namespace Urania.Core {
    public class OdCalculator {
        public static decimal Calculate(decimal? ar, decimal? wd, decimal? id) {


            if (id < 0) {
                throw new ArgumentOutOfRangeException($"{nameof(id)} cannot be less than 0");
            }
            if (ar < 0) {
                throw new ArgumentOutOfRangeException($"{nameof(ar)} cannot be less than 0");
            }
            if (wd < 0) {
                throw new ArgumentOutOfRangeException($"{nameof(wd)} cannot be less than 0");
            }

            if (id != null && ar != null) {

                if (ar == 0) {
                    throw new DivideByZeroException($"{nameof(ar)} cannot be 0");
                }

                return (decimal)(id + 2 * (id / ar));
            }

            if (wd != null && id != null) {
                return (decimal)(id + 2 * wd);
            }


            if (ar != null && wd != null) {
                return (decimal)(wd * (ar + 2));
            }

            throw new ArgumentNullException
                (string.Empty, $"Values: {nameof(id)} == {id}, {nameof(wd)} == {wd}, {nameof(wd)} == {wd}");
        }
    }
}