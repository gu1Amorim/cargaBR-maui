using System.Globalization;
using CargaBR.Models.Enums;

namespace CargaBR.Converters;

public class FreightStatusToLabelConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value switch
        {
            FreightStatus.Concluido => "Concluído",
            FreightStatus.EmAndamento => "Em andamento",
            _ => string.Empty
        };
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
