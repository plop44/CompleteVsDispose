using System;
using System.Globalization;
using System.Windows.Data;

namespace CompleteVsDispose
{
    public class TypeEqualsToAnythingConverter : IValueConverter
    {
        public object TrueValue { get; set; }
        public object FalseValue { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = parameter as Type;

            if (value != null && type?.IsAssignableFrom(value.GetType()) == true)
                return TrueValue;

            return FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}