using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace RyaRpc.Extensions
{
    public class BoolToStringConverter : Binding
    {
            public BoolToStringConverter()
            {
                Initialize();
            }

            public BoolToStringConverter(string path)
                : base(path)
            {
                Initialize();
            }

            public BoolToStringConverter(string path, object valueIfTrue, object valueIfFalse)
                : base(path)
            {
                Initialize();
                ValueIfTrue = valueIfTrue;
                ValueIfFalse = valueIfFalse;
            }

            private void Initialize()
            {
                ValueIfTrue = DoNothing;
                ValueIfFalse = DoNothing;
                Converter = new BoolConverter(this);
            }

            [ConstructorArgument("valueIfTrue")]
            public object ValueIfTrue { get; set; }

            [ConstructorArgument("valueIfFalse")]
            public object ValueIfFalse { get; set; }

            private class BoolConverter : IValueConverter
            {
                public BoolConverter(BoolToStringConverter switchExtension)
                {
                    _switch = switchExtension;
                }

                private readonly BoolToStringConverter _switch;

                #region IValueConverter Members

                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    try
                    {
                        var boolean = System.Convert.ToBoolean(value);
                        return boolean ? _switch.ValueIfTrue : _switch.ValueIfFalse;
                    }
                    catch
                    {
                        return DependencyProperty.UnsetValue;
                    }
                }

                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    return DoNothing;
                }

                #endregion
            }

        
    }
}
