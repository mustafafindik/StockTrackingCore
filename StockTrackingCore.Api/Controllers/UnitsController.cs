using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTrackingCore.Api.Dtos;
using StockTrackingCore.Business.Abstract;
using StockTrackingCore.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace StockTrackingCore.Api.Controllers
{
    [Route("api/units")]
    public class UnitsController : Controller
    {
        private readonly IUnitService _unitService;
        private readonly IMapper _mapper;
        public UnitsController(IUnitService unitService, IMapper mapper)
        {
            _unitService = unitService;
            _mapper = mapper;
        }



        [Route("getunits")]
        public ActionResult GetUnits()
        {
            try
            {
                var units = _unitService.GetAll();
                var unitLists = _mapper.Map<List<UnitListDto>>(units);
                return Ok(unitLists);
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
        public ActionResult GetUnitById(int id)
        {
            try
            {
                var unit = _unitService.Get(id);
                if (unit != null)
                {
                    var unitDetail = _mapper.Map<UnitDetailDto>(unit);
                    return StatusCode(200, unitDetail);
                }
                return NotFound(id + " id'li Birim bulumadı."); //Bad Request
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
        public ActionResult Add([FromBody] Unit unit)
        {
            try
            {
                unit.CreateDate = DateTime.Now;
                unit.CreatedBy = "AngularDefault";
                unit.ModifiedDate = DateTime.Now;
                unit.ModifiedBy = "AngularDefault";

                _unitService.Add(unit);
                return Ok(unit);
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
        public ActionResult Update([FromBody] Unit unit)
        {
            try
            {
                unit.ModifiedDate = DateTime.Now;
                unit.ModifiedBy = "AngularDefault";

                _unitService.Update(unit);
                return Ok(unit);
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
                var unit = _unitService.Get(id);
                if (unit != null)
                {
                    _unitService.Delete(id);
                    return Ok(unit);
                }
                else
                {
                    return NotFound("Birim Bulunamadı"); //Bad Request
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
        public ActionResult DeleteSelected([FromBody] List<int> ids)
        {
            try
            {

                _unitService.DeleteSelected(ids);
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
