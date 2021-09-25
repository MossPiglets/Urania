using System;

namespace Urania.Core {
    public class WdCalculator {
        public static decimal Calculate(decimal? id, decimal? ar, decimal? od) {
            if (id < 0) {
                throw new ArgumentOutOfRangeException(nameof(id), id, $"{nameof(id)} Cannot be less than 0");
            }
            if (ar < 0) {
                throw new ArgumentOutOfRangeException(nameof(ar), ar, $"{nameof(ar)} Cannot be less than 0");
            }
            if (od < 0) {
                throw new ArgumentOutOfRangeException(nameof(od), od, $"{nameof(od)} Cannot be less than 0");
            }
            if (id != null && ar != null) {
                if (ar == 0) {
                    throw new DivideByZeroException($"{nameof(ar)} cannot be 0");
                }
                return (decimal)(id / ar);
            }

            if (od != null && id != null) {
                if (od <= id) {
                    throw new ArgumentOutOfRangeException(nameof(od), od, $"{nameof(od)} must be greater than {nameof(id)}");
                }
                return (decimal)((od - id) / 2);
            }

            if (od != null && ar != null) {
                return (decimal)(od / (ar + 2));
            }

            throw new ArgumentNullException
                (string.Empty, $"Values: {nameof(id)} == {id}, {nameof(ar)} == {ar}, {nameof(od)} == {od}");
        }
    }
}
