using praktischeInformatikJB.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace praktischeInformatikJB.Converters
{
    internal class MatchDayColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SelectionState selectionState = (SelectionState)value;

            if (selectionState == SelectionState.MatchDay)
            {
                return System.Windows.Media.Colors.LightGreen;
            }

            return System.Windows.Media.Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
