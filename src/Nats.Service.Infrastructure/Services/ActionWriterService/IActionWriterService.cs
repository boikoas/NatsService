using System;
using System.Collections.Generic;
using System.Text;

namespace Nats.Service.Infrastructure.Services.ActionWriterService
{
    public interface IActionWriterService
    {
        void BeginConsume();
    }
}
