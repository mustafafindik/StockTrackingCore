using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTrackingCore.Api.Dtos;
using StockTrackingCore.Business.Abstract;
using StockTrackingCore.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace StockTrackingCore.Api.Controllers
{
    [Route("api/customers")]
    public class CustomersController : Controller
    {

        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [Route("getcustomers")]
        public ActionResult GetCustomers()
        {
            try
            {
                var customers = _customerService.GetAll();
                var customerLists = _mapper.Map<List<CustomerListDto>>(customers);
                return Ok(customerLists);
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
                var customer = _customerService.Get(id);
                if (customer != null)
                {
                    var detailDto = _mapper.Map<CustomerDetailDto>(customer);
                    return StatusCode(200, detailDto);
                }
                return NotFound(id + " id'li Müşteri bulumadı."); //Bad Request
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
        public ActionResult Add([FromBody] Customer customer)
        {
            try
            {
                customer.CreateDate = DateTime.Now;
                customer.CreatedBy = "AngularDefault";
                customer.ModifiedDate = DateTime.Now;
                customer.ModifiedBy = "AngularDefault";

                _customerService.Add(customer);
                return Ok(customer);
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
        public ActionResult Update([FromBody] Customer customer)
        {
            try
            {
                customer.ModifiedDate = DateTime.Now;
                customer.ModifiedBy = "AngularDefault";

                _customerService.Update(customer);
                return Ok(customer);
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
                var customer = _customerService.Get(id);
                if (customer != null)
                {
                    _customerService.Delete(id);
                    return Ok(customer);
                }
                else
                {
                    return NotFound("Müşteri Bulunamadı"); //Bad Request
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

                _customerService.DeleteSelected(ids);
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
