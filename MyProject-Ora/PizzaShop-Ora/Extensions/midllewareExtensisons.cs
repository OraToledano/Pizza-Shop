using Middleware;
namespace Extensions;
public static class WriteToLogMiddlewareExtensions
{
    public static IApplicationBuilder UseActionLog(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<WriteToLogMiddleware>();
    }
}