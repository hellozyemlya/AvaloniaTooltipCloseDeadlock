using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace AvToolTipBug;

public class TextToIntegerConverter : IMultiValueConverter
{
    /// <summary>
    /// Converts string value to integer number. If the string is not valid, returns -1, otherwise returns 1
    /// </summary>
    /// <param name="values">String value to convert</param>
    /// <param name="targetType">Integer value that returns if the requirements are met</param>
    /// <param name="parameter">Integer value to return</param>
    /// <param name="culture"></param>
    /// <returns>Return -1 or 1</returns>
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Count != 2)
        {
            return BindingOperations.DoNothing;
        }

        if (targetType.IsAssignableTo(typeof(int)))
        {
            string title = values[0] as string ?? string.Empty;
            string content = values[1] as string ?? string.Empty;
            if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(content))
            {
                return -1;
            }

            return 1;
        }

        // converter used for the wrong type
        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }
}