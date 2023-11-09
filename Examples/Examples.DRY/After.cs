using System.Text;

namespace Examples.KISS;

public class After
{
    public string ProcessObjectProperties(SimpleModel obj)
    {
        var result = new StringBuilder();

        result.AppendLine($"The Identifier is: {obj.Id}");
        result.AppendLine($"The Name is: {obj.Name}");

        return result.ToString();
    }
}