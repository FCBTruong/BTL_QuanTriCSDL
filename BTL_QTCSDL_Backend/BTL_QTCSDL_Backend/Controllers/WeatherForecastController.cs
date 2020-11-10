using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTL_QTCSDL_Backend.Models;
using Couchbase;
using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.N1QL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BTL_QTCSDL_Backend.Controllers
{
    [ApiController]
    public class MessageController : ControllerBase
    {
        private  IBucket _bucket;
        public MessageController(IBucketProvider bucketProvider)
        {
            _bucket = bucketProvider.GetBucket("A");
        }

        [HttpGet]
        [Route("/Message/Get")]
        public async Task<ActionResult<IEnumerable<string>>> Get(string id)
        {
            var queryRequest = new QueryRequest()
      .Statement("SELECT * FROM `A` LIMIT $1");

            var result = await _bucket.QueryAsync<dynamic>(queryRequest);
            if (!result.Success)
            {
                return BadRequest("xx");
            }
            Console.WriteLine("sssd");
           // return BadRequest("xx");
            return Ok(result);
        }

        [HttpPost]
        [Route("/Message/Store")]
        public async Task<IActionResult> Store(Message message)
        {
           var result = await _bucket.InsertAsync(Guid.NewGuid().ToString(), message);
            if (!result.Success)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
