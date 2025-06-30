using its.gamify.core.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace its.gamify.api.Extensions;

public static class HttpRequestExtensions
{
    /// <summary>
    /// Trích xuất thông tin OrderBy từ query string có định dạng order_by[i][order_column] và order_by[i][order_dir]
    /// </summary>
    /// <param name="request">HttpRequest cần xử lý</param>
    /// <returns>Danh sách OrderByItem được trích xuất từ query string</returns>
    public static List<OrderByItem> ExtractOrderByItems(this HttpRequest request)
    {
        var orderByItems = new List<OrderByItem>();
        var query = request.Query;

        for (int i = 0; ; i++)
        {
            var columnKey = $"order_by[{i}][order_column]";
            var dirKey = $"order_by[{i}][order_dir]";

            if (!query.ContainsKey(columnKey))
                break;

            orderByItems.Add(new OrderByItem
            {
                OrderColumn = query[columnKey].ToString(),
                OrderDir = query.ContainsKey(dirKey) ? query[dirKey].ToString() : "ASC"
            });
        }

        return orderByItems;
    }
}

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
public class ProcessOrderByAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Tìm tất cả tham số BaseQueryDto trong action
        foreach (var kvp in context.ActionArguments)
        {
            if (kvp.Value is BaseQueryDto queryDto)
            {
                var orderByItems = context.HttpContext.Request.ExtractOrderByItems();
                queryDto.OrderBy.AddRange(orderByItems);
            }
        }

        base.OnActionExecuting(context);
    }
}