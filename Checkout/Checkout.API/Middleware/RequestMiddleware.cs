using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Prometheus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.API.Middleware
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public RequestMiddleware(RequestDelegate requestDelegate, ILoggerFactory loggerFactory)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path.Value;
            var method = httpContext.Request.Method;

            var counter = Metrics.CreateCounter("request_total", "HTTP Requests Total", new CounterConfiguration
            {
                LabelNames = new[] { "path", "method", "status" }
            });

            var statusCode = 200;

            try
            {
                await _requestDelegate.Invoke(httpContext);
            }
            catch (Exception)
            {
                statusCode = 500;
                counter.Labels(path, method, statusCode.ToString()).Inc();

                throw;
            }

            if (path != "/metrics")
            {
                statusCode = httpContext.Response.StatusCode;
                counter.Labels(path, method, statusCode.ToString()).Inc();
            }
        }
    }
}