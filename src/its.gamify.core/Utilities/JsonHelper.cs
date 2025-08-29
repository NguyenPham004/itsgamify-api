using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace its.gamify.core.Utilities;

/// <summary>
/// Lớp tiện ích để xử lý chuyển đổi JSON với cấu hình nhất quán
/// </summary>
public static class JsonHelper
{
    /// <summary>
    /// Chuyển đổi đối tượng thành chuỗi JSON với cấu hình chuẩn của ứng dụng
    /// </summary>
    /// <param name="obj">Đối tượng cần chuyển đổi</param>
    /// <returns>Chuỗi JSON đã được định dạng</returns>
    public static string SerializeObject(object obj)
    {
        return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        });
    }
}