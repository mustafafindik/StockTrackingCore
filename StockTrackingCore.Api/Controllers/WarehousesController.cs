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
    }
}