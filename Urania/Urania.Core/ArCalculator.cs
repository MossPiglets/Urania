using System;

namespace Urania.Core {
    public class ArCalculator {
        public static decimal Calculate(decimal? id, decimal? wd, decimal? od) {
            if (wd?.GetType() == typeof(decimal) && od?.GetType() == typeof(decimal)) {
                return Math.Round((decimal) ((od - 2 * wd) / wd), 2);
            }

            if (id?.GetType() == typeof(decimal) && od?.GetType() == typeof(decimal)) {
                return Math.Round((decimal) (id / ((od - id) / 2)), 2);
            }

            if (id?.GetType() == typeof(decimal) && wd?.GetType() == typeof(decimal)) {
                return Math.Round((decimal) (id / wd), 2);
            }

            throw new ArgumentException("More than one null argument");
        }
    }
}