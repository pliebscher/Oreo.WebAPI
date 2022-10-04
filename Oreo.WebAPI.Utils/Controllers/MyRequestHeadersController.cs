using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Oreo.WebAPI.Utils.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyRequestHeadersController : ControllerBase
    {
        // GET: api/MyRequestHeaders
        [HttpGet]
        public IEnumerable<KeyValuePair<string, StringValues>> Get()
        {
            IHeaderDictionary headers = Request.Headers;

            return headers; // new string[] { "value1", "value2" };
        }

        // GET api/MyRequestHeaders/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST api/MyRequestHeaders
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/MyRequestHeaders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/MyRequestHeaders/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
