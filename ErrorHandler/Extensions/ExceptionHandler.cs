using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ErrorHandler.Extensions
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _delegate;
        public ExceptionHandler(RequestDelegate @delegate)
        {
            _delegate = @delegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _delegate.Invoke(context);
                if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    context.Response.Redirect("/Home/Error");
                }
            }
            catch (Exception ex)
            {
                context.Response.Redirect("/Home/Error");
            }

        }
    }
}
