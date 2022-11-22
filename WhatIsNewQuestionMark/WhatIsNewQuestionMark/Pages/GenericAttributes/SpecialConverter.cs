using System.Globalization;
using System.Reflection;

namespace WhatIsNewQuestionMark.Pages.GenericAttributes;

class SpecialConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return null;

        var specialAttr = (SpecialAttribute?)value
            .GetType()
            .GetCustomAttribute(typeof(SpecialAttribute));

        // not special
        if (specialAttr == null)
            return "⚠️ " + value.ToString();

        //var specialType = specialAttr.GetType().GenericTypeArguments[0];
        var specialType = specialAttr.SpecialType;
        var special = (ISpecial)Activator.CreateInstance(specialType)!;

        // super special
        if (special.IsSuperSpecial)
            return "💓 " + value.ToString();

        // normal special
        return "❤️ " + value.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}
