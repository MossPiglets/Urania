using System;

namespace Urania.Core {
    public class ArCalculator {
        public static decimal Calculate(decimal? id, decimal? wd, decimal? od) {
            if (id < 0) {
                throw new ArgumentOutOfRangeException(nameof(id), id, $"{nameof(id)} cannot be less than 0");
            }

            if (wd < 0) {
                throw new ArgumentOutOfRangeException(nameof(wd), wd, $"{nameof(wd)} cannot be less than 0");
            }

            if (od < 0) {
                throw new ArgumentOutOfRangeException(nameof(od), od, $"{nameof(od)} cannot be less than 0");
            }
            if (wd != null && od != null) {
                if (wd == 0) {
                    throw new DivideByZeroException($"{nameof(wd)} cannot be 0");
                }

                if (od < 2 * wd) {
                    throw new ArgumentOutOfRangeException(nameof(od), od,
                        $"{nameof(od)} cannot be twice as small as {nameof(wd)}");
                }
                return (decimal) ((od - 2 * wd) / wd);
            }

            if (id != null && od != null) {
                if (od == id) {
                    throw new DivideByZeroException($"{nameof(od)} cannot be equal {nameof(id)}");
                }

                if (od < id) {
                    throw new ArgumentOutOfRangeException(nameof(od), od,
                        $"{nameof(od)} cannot be less than {nameof(id)}");
                }
                return (decimal) (id / ((od - id) / 2));
            }

            if (id != null && wd != null) {
                if (wd == 0) {
                    throw new DivideByZeroException($"{nameof(wd)} cannot be 0");
                }
                return (decimal) (id / wd);
            }

            throw new ArgumentNullException
                (string.Empty, $"Values: {nameof(id)} == {id}, {nameof(wd)} == {wd}, {nameof(od)} == {od}");
        }
    }
}