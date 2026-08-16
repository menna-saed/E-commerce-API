namespace Ecommerce.Domain.common;

public class ProductQueryParameters
{

    public Guid ? brandId { get; set; }  = null ;
    public Guid ? typeId  { get; set; }= null;

    public String?  Name { get; set; }
    public OrderBy? OrderBy { get; set; }
    
    public int?  PageNumber { get; set; } 
    public int? PageSize { get; set; } 
    public int? TotalCount { get; set; }
    
    public bool IsPagingEnabled = false;


}