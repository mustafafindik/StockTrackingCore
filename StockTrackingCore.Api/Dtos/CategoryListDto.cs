using System.Collections.Generic;

namespace StockTrackingCore.Api.Dtos
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<SubCategoryListDto> SubCategories { get; set; }
    }

    public class SubCategoryListDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ParentCategoryid { get; set; }
    }
}
