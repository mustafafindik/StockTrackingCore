using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTrackingCore.Api.Dtos;
using StockTrackingCore.Business.Abstract;
using StockTrackingCore.Entities.Concrete;

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



        [HttpPost]
        [Route("addCategory")]
        public ActionResult AddCategory([FromBody] Category category)
        {
            try
            {
                category.CreateDate = DateTime.Now;
                category.CreatedBy = "AngularDefault";
                category.ModifiedDate = DateTime.Now;
                category.ModifiedBy = "AngularDefault";

                _categoryService.Add(category);
                return Ok(category);
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


        [HttpPut]
        [Route("updateCategory")]
        public ActionResult UpdateCategory([FromBody] Category category)
        {
            try
            {
                category.ModifiedDate = DateTime.Now;
                category.ModifiedBy = "AngularDefault";

                _categoryService.Update(category);
                return Ok(category);
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

        [HttpDelete]
        [Route("deleteCategory/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                var category = _categoryService.Get(id);
                if (category != null)
                {
                    _categoryService.Delete(id);
                    return Ok(category);
                }
                else
                {
                    return NotFound("Kategori Bulunamadı"); //Bad Request
                }

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


        [HttpPost]
        [Route("addSubCategory")]
        public ActionResult AddSubCategory([FromBody] SubCategory subCategory)
        {
            try
            {
                subCategory.CreateDate = DateTime.Now;
                subCategory.CreatedBy = "AngularDefault";
                subCategory.ModifiedDate = DateTime.Now;
                subCategory.ModifiedBy = "AngularDefault";

                _subCategoryService.Add(subCategory);
                return Ok(subCategory);
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


        [HttpPut]
        [Route("updateSubCategory")]
        public ActionResult UpdateSubCategory([FromBody] SubCategory subCategory)
        {
            try
            {
                subCategory.ModifiedDate = DateTime.Now;
                subCategory.ModifiedBy = "AngularDefault";

                _subCategoryService.Update(subCategory);
                return Ok(subCategory);
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

        [HttpDelete]
        [Route("deleteSubCategory/{id}")]
        public ActionResult DeleteSubCategory(int id)
        {
            try
            {
                var subCategory = _subCategoryService.Get(id);
                if (subCategory != null)
                {
                    _subCategoryService.Delete(id);
                    return Ok(subCategory);
                }
                else
                {
                    return NotFound("Alt Kategori Bulunamadı"); //Bad Request
                }

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
