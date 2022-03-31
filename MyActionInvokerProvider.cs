using Microsoft.AspNetCore.Mvc.Abstractions;

namespace pjstub
{
    internal class MyActionInvokerProvider : IActionInvokerProvider
    {
        /// <summary>
        /// This Order value must be lower than the ones from:
        /// - PageActionInvokerProvider
        /// - ControllerActionInvokerProvider
        /// </summary>
        public int Order => -100000;

        public void OnProvidersExecuting(ActionInvokerProviderContext context)
        {
            // Resolve Ext Context
            //var actionCtx = context.ActionContext;
            //var httpCtx = actionCtx.HttpContext;
            //var extCtx = httpCtx.RequestServices.GetRequiredService<IExtCtx>();

            // Persist Action Context in Ext Context.
            //
            // Keeping ActionContext is specifically required when
            // `FallbackToStreamRender = true` (stream injection mode).
            //extCtx.ActionCtx = actionCtx;
            //throw new Exception("I was here exception -tm-.");
            Console.WriteLine("Updated Action Context.");
            Stub.ActionInvokeCount++;
        }

        public void OnProvidersExecuted(ActionInvokerProviderContext context)
        {
            // Do nothing
        }
    }
}
