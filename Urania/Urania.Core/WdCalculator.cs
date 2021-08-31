using System;

namespace Urania.Core {
    public class WdCalculator {
        public static decimal Calculate(decimal? id, decimal? ar, decimal? od) {
            if (id != null && ar != null) {
                if (ar == 0) {
                    throw new DivideByZeroException($"{nameof(ar)} cannot be 0");
                }
                return (decimal)(id / ar);
            }

            if (od != null && id != null) {
                return (decimal)((od - id) / 2);
            }

            if (od != null && ar != null) {
                if (ar == -2) {
                    throw new DivideByZeroException($"{nameof(ar)} cannot be equal -2");
                }
                return (decimal)(od / (ar + 2));
            }

            throw new ArgumentNullException
                (string.Empty, $"Values: {nameof(id)} == {id}, {nameof(ar)} == {ar}, {nameof(od)} == {od}");
        }
    }
}
