using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace its.gamify.core.Models;

public class BaseQueryDto
{
    /// <summary>
    /// Số trang, bắt đầu từ 0
    /// </summary>
    public int Page { get; set; } = 0;

    /// <summary>
    /// Số lượng bản ghi trên mỗi trang
    /// </summary>
    public int Limit { get; set; } = 10;

    /// <summary>
    /// Từ khóa tìm kiếm
    /// </summary>
    public string? Q { get; set; } = null;

    /// <summary>
    /// Danh sách các điều kiện sắp xếp (sẽ được xử lý thủ công)
    /// </summary>
    [JsonIgnore]
    [BindNever]
    public List<OrderByItem> OrderBy { get; set; } = new List<OrderByItem>();
}

internal class SwaggerSchemaAttribute : Attribute
{
}

public class OrderByItem
{
    public string OrderColumn { get; set; } = string.Empty;
    public string OrderDir { get; set; } = "ASC";
}


