using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oreo.WebAPI.Utils.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyIPAddressController : ControllerBase
    {
        // GET: api/MyIPAddress
        [HttpGet]
        public string Get()
        {
            return HttpContext.Connection.RemoteIpAddress.ToString();
        }
    }
}
