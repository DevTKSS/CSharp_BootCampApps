using System.Text.Json.Serialization;

namespace WebServices.DataModels;
public partial class ImageData
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    [JsonPropertyName("width")]
    public int? Width { get; set; }
    [JsonPropertyName("height")]
    public int? Height { get; set; }
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
