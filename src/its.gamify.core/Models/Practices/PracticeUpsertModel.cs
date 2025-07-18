using System.Text.Json.Serialization;

namespace its.gamify.core.Models.Practices
{
    public class PracticeUpsertModel
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}
