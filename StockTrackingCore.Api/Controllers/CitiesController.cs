using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTrackingCore.Api.Dtos;
using StockTrackingCore.Business.Abstract;
using StockTrackingCore.Entities.Concrete;
using System;
using System.Collections.Generic;

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
                var cities = _cityService.GetAll();
                var citiesMap = _mapper.Map<List<CityListDto>>(cities);
                return StatusCode(200, citiesMap);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); //Bad Request
            }

        }

        [HttpGet]
        [Route("detail/{id}")]
        public ActionResult GetCityById(int id)
        {
            var city = _cityService.Get(id);
            return StatusCode(200, city);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody] City city)
        {
            _cityService.Add(city);
            return Ok(city);

        }
    }
}
