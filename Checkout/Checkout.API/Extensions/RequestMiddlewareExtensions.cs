using Checkout.API.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.API.Extensions
{
    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestMiddleware>();
        }
    }
}