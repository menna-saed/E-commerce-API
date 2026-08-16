using System.Text.Json.Serialization;
using Ecommerce.Domain.common;
using Ecommerce.Domain.Common;

namespace Ecommerce.API.Models;

public class ApiResponse<T>
{
    public bool Success { get; set; } = true;
    public T? Data { get; set; }
    public string? Message { get; set; }
    public ApiMeta Meta { get; set; } = new ApiMeta();

    public static ApiResponse<T> Ok (T data,
        string traceId,
        string? message = null,
        PaginationMeta? pagination = null)
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data,
            Message = message,
            Meta = new ApiMeta()
            {
                TraceId = traceId,
                Pagination = pagination
            }
        };
    }

   
        
    

}

public class ApiMeta
{
    public string TraceId { get; set; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PaginationMeta? Pagination { get; set; } = null;
}

