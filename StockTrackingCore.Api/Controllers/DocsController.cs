using Microsoft.AspNetCore.Mvc;

namespace StockTrackingCore.Api.Controllers
{
    public class DocsController : Controller
    {
        [HttpGet]
        [Route("api/[controller]")]

        public string Get()
        {
            return new string("Stok Yönetim Api'sine Hoşgeldiniz.");
        }
    }
}
