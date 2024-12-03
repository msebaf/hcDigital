using System.Text.Json;
using System.Text.Json.Serialization;

public class DateOnlyJsonConverter : JsonConverter<DateOnly?>
{
    private readonly string _format = "yyyy-MM-dd";

    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string? dateStr = reader.GetString();
            if (!string.IsNullOrEmpty(dateStr) && DateOnly.TryParseExact(dateStr, _format, out DateOnly date))
            {
                return date;
            }
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString(_format));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
