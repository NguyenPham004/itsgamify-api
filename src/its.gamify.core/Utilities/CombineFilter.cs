using System.Linq.Expressions;


namespace its.gamify.core.Utilities;

public static class FilterCustom
{
    public static Expression<Func<T, bool>> CombineFilters<T>(
        Expression<Func<T, bool>> first,
        Expression<Func<T, bool>> second)
    {
        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.AndAlso(
            Expression.Invoke(first, parameter),
            Expression.Invoke(second, parameter));
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}