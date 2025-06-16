using its.gamify.domains.Models;
using System.Text.Json.Serialization;

namespace its.gamify.core.Models.ShareModels
{
    public class BasePagingResponseModel<TData>
    {
        [JsonPropertyName("data")]
        public List<TData> Datas { get; set; } = [];
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = new();
        public BasePagingResponseModel(List<TData> datas, Pagination pagination)
        {
            this.Datas = datas;
            this.Pagination = pagination;
        }
    }
}
