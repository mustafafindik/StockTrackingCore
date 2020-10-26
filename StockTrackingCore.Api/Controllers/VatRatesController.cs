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
    [Route("api/vatrates")]
    public class VatRatesController : Controller
    {
        private readonly IVatRateService _vatRateService;
        private readonly IMapper _mapper;
        public VatRatesController(IVatRateService vatRateService, IMapper mapper)
        {
            _vatRateService = vatRateService;
            _mapper = mapper;
        }
        [Route("getvatrates")]
        public ActionResult GetVatRates()
        {
            try
            {
                var vatRates = _vatRateService.GetAll();
                var vatRateLists = _mapper.Map<List<VatRateListDto>>(vatRates);
                return Ok(vatRateLists);
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
        public ActionResult GetVatRateById(int id)
        {
            try
            {
                var vatRate = _vatRateService.Get(id);
                if (vatRate != null)
                {
                    var vatRateDetail = _mapper.Map<VatRateDetailDto>(vatRate);
                    return StatusCode(200, vatRateDetail);
                }
                return NotFound(id + " id'li KDV Oranı bulumadı."); //Bad Request
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
        public ActionResult Add([FromBody] VatRate vatRate)
        {
            try
            {
                vatRate.CreateDate = DateTime.Now;
                vatRate.CreatedBy = "AngularDefault";
                vatRate.ModifiedDate = DateTime.Now;
                vatRate.ModifiedBy = "AngularDefault";

                _vatRateService.Add(vatRate);
                return Ok(vatRate);
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
        public ActionResult Update([FromBody] VatRate vatRate)
        {
            try
            {
                vatRate.ModifiedDate = DateTime.Now;
                vatRate.ModifiedBy = "AngularDefault";

                _vatRateService.Update(vatRate);
                return Ok(vatRate);
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
                var vatRate = _vatRateService.Get(id);
                if (vatRate != null)
                {
                    _vatRateService.Delete(id);
                    return Ok(vatRate);
                }
                else
                {
                    return NotFound("Kdv Oranı Bulunamadı"); //Bad Request
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

                _vatRateService.DeleteSelected(ids);
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
