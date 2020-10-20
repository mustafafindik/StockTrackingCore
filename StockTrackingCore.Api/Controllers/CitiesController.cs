using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTrackingCore.Api.Dtos;
using StockTrackingCore.Business.Abstract;
using StockTrackingCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrackingCore.Api.Controllers
{
    [Route("api/Cities")]
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        public CitiesController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [Route("getcities")]
        public ActionResult GetCities()
        {
            try
            {
                var cities  = _cityService.GetAll();
                var citiesMap = _mapper.Map<List<CityListDto>>(cities);
                return Ok(citiesMap);
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

        [HttpGet]
        [Route("detail/{id}")]
        public ActionResult GetCityById(int id)
        {
            try
            {
                var city = _cityService.Get(id);
                if (city != null)
                {
                    var cityMap = _mapper.Map<CityDetailDto>(city);
                    return StatusCode(200, cityMap);
                }
                return NotFound(id + " id'li Şehir bulumadı."); //Bad Request
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
        [Route("add")]
        public ActionResult Add([FromBody] City city)
        {
            try
            {
                city.CreateDate = DateTime.Now;
                city.CreatedBy = "AngularDefault";
                city.ModifiedDate = DateTime.Now;
                city.ModifiedBy = "AngularDefault";

                _cityService.Add(city);
                return Ok(city);
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
        [Route("update")]
        public ActionResult Update([FromBody] City city)
        {
            try
            {
                city.ModifiedDate = DateTime.Now;
                city.ModifiedBy = "AngularDefault";

                _cityService.Update(city);
                return Ok(city);
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
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var city = _cityService.Get(id);
                if (city != null)
                {
                    _cityService.Delete(id);
                    return Ok(city);
                }
                else
                {
                    return NotFound("Şehir Bulunamadı"); //Bad Request
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
        [Route("deleteselected")]
        public ActionResult DeleteSelected([FromBody]  List<int> ids)
        {
            try
            {
               
                    _cityService.DeleteSelected(ids);
                    return Ok();
               

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
