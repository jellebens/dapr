using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapr.Actors;

namespace Dapr.Core.Actors
{
    public interface IOperationActor:IActor
    {
        public Task Start();
    }
}
