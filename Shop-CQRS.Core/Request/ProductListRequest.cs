namespace Shop_CQRS.Core.Request
{
    public class ProductListRequest
    {
        public static int PageSize { get; set; } = 4;
        public static int ProductPage { get; set; } = 1;
    }
}
