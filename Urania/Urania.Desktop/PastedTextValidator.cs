using System.Linq;
using System.Windows;

namespace Urania.Desktop {
    class PastedTextValidator {
        public static void AllowPastOnlyNumbers(DataObjectPastingEventArgs e) {
            if (e.DataObject.GetDataPresent(typeof(string))) {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!decimal.TryParse(text, out _)) {
                    e.CancelCommand();
                }
            }
            else {
                e.CancelCommand();
            }
        }
    }
}
