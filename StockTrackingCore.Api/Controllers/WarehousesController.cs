using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTrackingCore.Api.Dtos;
using StockTrackingCore.Business.Abstract;
using StockTrackingCore.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace StockTrackingCore.Api.Controllers
{
    [Route("api/Warehouses")]
    public class WarehousesController : Controller
    {

        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;
        public WarehousesController(IWarehouseService warehouseService, IMapper mapper)
        {
            _warehouseService = warehouseService;
            _mapper = mapper;
        }

        [Route("getwarehouses")]
        public ActionResult GetWarehouses()
        {
            try
            {
                var warehouses = _warehouseService.GetAll("City");
                var warehouseLists = _mapper.Map<List<WarehouseListDto>>(warehouses);
                return Ok(warehouseLists);
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
        public ActionResult GetWarehouseById(int id)
        {
            try
            {
                var warehouse = _warehouseService.Get(id, "City");
                if (warehouse != null)
                {
                    var warehouseDetail = _mapper.Map<WarehouseDetailDto>(warehouse);
                    return StatusCode(200, warehouseDetail);
                }
                return NotFound(id + " id'li Depo bulumadı."); //Bad Request
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
        public ActionResult Add([FromBody] Warehouse warehouse)
        {
            try
            {
                warehouse.CreateDate = DateTime.Now;
                warehouse.CreatedBy = "AngularDefault";
                warehouse.ModifiedDate = DateTime.Now;
                warehouse.ModifiedBy = "AngularDefault";

                _warehouseService.Add(warehouse);
                return Ok(warehouse);
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
        public ActionResult Update([FromBody] Warehouse warehouse)
        {
            try
            {
                warehouse.ModifiedDate = DateTime.Now;
                warehouse.ModifiedBy = "AngularDefault";

                _warehouseService.Update(warehouse);
                return Ok(warehouse);
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
                var warehouse = _warehouseService.Get(id);
                if (warehouse != null)
                {
                    _warehouseService.Delete(id);
                    return Ok(warehouse);
                }
                else
                {
                    return NotFound("Depo Bulunamadı"); //Bad Request
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

                _warehouseService.DeleteSelected(ids);
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