using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapr.Actors;
using Dapr.Actors.Client;
using Dapr.Core.Actors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dapr.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _Logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _Logger = logger;
        }
        [HttpGet("start/{id}")]
        public async Task<IActionResult> Start(string id) {
            var actorType = "OperationActor";      // Registered Actor Type in Actor Service

            
            var actorID = new ActorId(id);

            _Logger.LogInformation($"Start Transaction with id {id}");

            var proxy = ActorProxy.Create<IOperationActor>(actorID, actorType);
            
            await proxy.Start();

            _Logger.LogInformation($"Finished Transaction with id {id}");

            return Ok();

        }
    }
}
