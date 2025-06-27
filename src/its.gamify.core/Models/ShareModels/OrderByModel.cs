using System.Text.Json.Serialization;

namespace its.gamify.core.Models.ShareModels
{
    public class OrderByModel
    {
        [JsonPropertyName("order_by")]
        public string OrderColumn { get; set; } = string.Empty;
        public string OrderDir { get; set; } = string.Empty;
    }
}
