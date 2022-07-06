using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Contacts.WPF.ValueConverters
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members

        private static T Converter = null;

        #endregion Private Members

        #region Markup Extension Methods

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Converter ??= new T();
        }

        #endregion Markup Extension Methods

        #region Value Converter Methods

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion Value Converter Methods
    }
}