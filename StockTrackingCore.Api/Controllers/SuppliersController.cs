using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTrackingCore.Api.Dtos;
using StockTrackingCore.Business.Abstract;
using StockTrackingCore.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace StockTrackingCore.Api.Controllers
{
    [Route("api/suppliers")]
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public SuppliersController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [Route("getsuppliers")]
        public ActionResult GetSuppliers()
        {
            try
            {
                var suppliers = _supplierService.GetAll();
                var supplierLists = _mapper.Map<List<SupplierListDto>>(suppliers);
                return Ok(supplierLists);
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
        public ActionResult GetSupplierById(int id)
        {
            try
            {
                var supplier = _supplierService.Get(id);
                if (supplier != null)
                {
                    var detailDto = _mapper.Map<SupplierDetailDto>(supplier);
                    return StatusCode(200, detailDto);
                }
                return NotFound(id + " id'li Tedarikçi bulumadı."); //Bad Request
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
        public ActionResult Add([FromBody] Supplier supplier)
        {
            try
            {
                supplier.CreateDate = DateTime.Now;
                supplier.CreatedBy = "AngularDefault";
                supplier.ModifiedDate = DateTime.Now;
                supplier.ModifiedBy = "AngularDefault";

                _supplierService.Add(supplier);
                return Ok(supplier);
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
        public ActionResult Update([FromBody] Supplier supplier)
        {
            try
            {
                supplier.ModifiedDate = DateTime.Now;
                supplier.ModifiedBy = "AngularDefault";

                _supplierService.Update(supplier);
                return Ok(supplier);
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
                var supplier = _supplierService.Get(id);
                if (supplier != null)
                {
                    _supplierService.Delete(id);
                    return Ok(supplier);
                }
                else
                {
                    return NotFound("Tedarikçi Bulunamadı"); //Bad Request
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

                _supplierService.DeleteSelected(ids);
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
