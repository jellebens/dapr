using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dapr.Core.Actors
{
    public interface ISubOperation
    {
        public Task Start();
    }
}
