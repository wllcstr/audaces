using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Audaces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Audaces.Controllers
{
    [Route("api/sequence")]
    [ApiController]
    public class SequenceOutput : ControllerBase
    {

        [HttpPost]
        public async Task<string> GetPossibleCalc([FromBody]  Compose sequence)
        {
            return await sequence.calculateFactor();

        }
    }
}
