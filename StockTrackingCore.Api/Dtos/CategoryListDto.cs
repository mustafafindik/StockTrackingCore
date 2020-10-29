using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public int ParentCategoryId { get; set; }
    }
}
