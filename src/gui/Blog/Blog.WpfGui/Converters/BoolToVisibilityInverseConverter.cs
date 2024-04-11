using System.Globalization;
using System.Windows.Data;

namespace Blog.WpfGui.Converters;

public class BoolToVisibilityInverseConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var booleanVal = (bool)value;

        if (booleanVal)
        {
            return Visibility.Collapsed;
        }

        return Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
