using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTrackingCore.Api.Dtos;
using StockTrackingCore.Business.Abstract;

namespace StockTrackingCore.Api.Controllers
{
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, ISubCategoryService subCategoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _mapper = mapper;
        }
        [Route("getcategories")]
        public ActionResult GetCategories()
        {
            try
            {
                var categories = _categoryService.GetAll("SubCategories");
                var categoryLists = _mapper.Map<List<CategoryListDto>>(categories);
                return Ok(categoryLists);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return NotFound(ex.InnerException.Message); //Bad Request
                }
                else
                {
                    return NotFound(ex.Message); //Bad Request
                }

            }

        }
    }
}
