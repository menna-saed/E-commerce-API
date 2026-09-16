using System.Text;
using Ecommerce.Application.Caching.Services;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.API.Filters;

public class CachingFilter : IEndpointFilter
{
    private static readonly TimeSpan DefaultExpiry = TimeSpan.FromMinutes(30);

    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var cacheService =
            context.HttpContext.RequestServices
                .GetRequiredService<ICacheService>();

        var key = CreateCacheKey(context.HttpContext.Request);

        var cached = await cacheService.GetAsync<string>(key);
        if (cached.IsSuccess)
        {
            return Results.Content(cached.Value!, "application/json");
        }

        
        // 2 Stream (originalBodyStream) الاصلي الللي هيرجع للuser ,responseBody  اللي هخزنه 
        var originalBodyStream = context.HttpContext.Response.Body;
        using var responseBody = new MemoryStream();
        context.HttpContext.Response.Body = responseBody;

        var result = await next(context);

        if (result is IResult executableResult)
        {
            await executableResult.ExecuteAsync(context.HttpContext);

            if (context.HttpContext.Response.StatusCode == StatusCodes.Status200OK)
            {
                // يرجع المؤشر للبدايه الداتا يقراها 
                responseBody.Seek(0, SeekOrigin.Begin);
                
                //JSON
                var text = await new StreamReader(responseBody).ReadToEndAsync();
                
                //خزن
                await cacheService.SetAsync(key, text, timeToLive: DefaultExpiry);

                
                // تتعرض client 
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
            else
            {
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }

            context.HttpContext.Response.Body = originalBodyStream;
            return Results.Empty;
        }

        context.HttpContext.Response.Body = originalBodyStream;
        return result;
    }

    private static string CreateCacheKey(HttpRequest request)
    {
        var key = new StringBuilder();

        key.Append(request.Path);

        foreach (var item in request.Query.OrderBy(x => x.Key))
        {
            key.Append($"|{item.Key}:{item.Value}");
        }

        return key.ToString();
    }
}
