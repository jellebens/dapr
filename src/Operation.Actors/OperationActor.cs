using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapr.Actors;
using Dapr.Actors.Runtime;
using Dapr.Core.Actors;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Operation.Actors
{
    public class OperationActor : Actor, IOperationActor
    {
        private ILogger<OperationActor> _Logger;

        public OperationActor(ActorService service, ActorId actorId)
            : base(service, actorId)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddConsole(config => {
                        config.Format = ConsoleLoggerFormat.Systemd;
                        config.TimestampFormat = "[HH:mm:ss] ";
                    });
            });

            _Logger = loggerFactory.CreateLogger<OperationActor>();
        }

        public async Task Start()
        {
            _Logger.LogInformation("Started Operation");

            await this.StateManager.SetStateAsync<string>("status", "started");

            _Logger.LogInformation("Finished");
        }
    }
}
