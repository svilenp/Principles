using System.Text;

namespace Examples.KISS;

public class Before
{
    public string ProcessObjectProperties(SimpleModel obj)
    {
        var result = new StringBuilder();

        var properties = obj.GetType().GetProperties();

        foreach (var property in properties)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(obj);

            var nameFormatter = new NameFormatter();

            var formattedName = nameFormatter.FormatName(propertyName);

            result.AppendLine($"{formattedName}: {propertyValue}");
        }

        return result.ToString();
    }
}

public class NameFormatter
{
    public string FormatName(string propertyName)
    {
        return propertyName switch
        {
            nameof(NamesEnum.Id) => GetMessage("Identifier"),
            nameof(NamesEnum.Name) => GetMessage("Name"),
            _ => string.Empty,
        };
    }

    private string GetMessage(string description)
    {
        return $"The {description} is";
    }
}

public enum NamesEnum
{
    Id,
    Name
}