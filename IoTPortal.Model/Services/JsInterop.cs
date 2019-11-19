using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Infrastructure;

namespace IoTPortal.Model.Services
{
    public class JsInterop : JSRuntime
    {
        protected override void BeginInvokeJS(long taskId, string identifier, string argsJson)
        {
            throw new NotImplementedException();
        }

        protected override void EndInvokeDotNet(DotNetInvocationInfo invocationInfo, in DotNetInvocationResult invocationResult)
        {
            throw new NotImplementedException();
        }
    }
}
