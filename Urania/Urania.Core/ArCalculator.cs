using System;

namespace Urania.Core {
    public class ArCalculator {
        public static decimal Calculate(decimal? id, decimal? wd, decimal? od) {
            if (wd != null && od != null) {
                if (wd == 0) {
                    throw new DivideByZeroException($"{nameof(wd)} cannot be 0");
                }
                return (decimal) ((od - 2 * wd) / wd);
            }

            if (id != null && od != null) {
                if (od == id) {
                    throw new DivideByZeroException($"{nameof(od)} cannot be equal {nameof(id)}");
                }
                return (decimal) (id / ((od - id) / 2));
            }

            if (id != null && wd != null) {
                if (wd == 0) {
                    throw new DivideByZeroException($"{nameof(wd)} cannot be 0");
                }
                return (decimal) (id / wd);
            }

            throw new ArgumentNullException(string.Empty, $"Values: Id == {id}, Wd == {wd}, Od == {od}");
        }
    }
}