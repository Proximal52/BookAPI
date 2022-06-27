using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace BookAPI.Infrastracture
{
    public class ExceptionHandlerMiddleware
    {
        public async Task Invoke(HttpContext context)
        {
            var contextExceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextExceptionFeature is not null && contextExceptionFeature.Error is not null)
            {
                context.Response.StatusCode = (int)GetErrorCode(contextExceptionFeature.Error);
            }

            await Task.CompletedTask;
        }

        private static HttpStatusCode GetErrorCode(Exception e)
        {
            switch (e)
            {
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
