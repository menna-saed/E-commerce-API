namespace Ecommerce.API.Models;

public class PaginationMeta
{
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }

    public static PaginationMeta? Create(
        int? page,
        int? pageSize,
        int totalCount = 10)
    {
        if (!page.HasValue || !pageSize.HasValue || pageSize <= 0)
            return null;

        return new PaginationMeta
        {
            Page = page,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(
                totalCount / (double)pageSize.Value
            )
        };
    }
    }
