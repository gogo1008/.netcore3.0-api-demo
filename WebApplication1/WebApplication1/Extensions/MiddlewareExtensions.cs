using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Middlewares;

namespace WebApplication1.Extensions
{
    #region snippet1
    public static class MiddlewareExtensions
    {
        //public static IApplicationBuilder UseConventionalMiddleware(
        //    this IApplicationBuilder builder)
        //{
        //    return builder.UseMiddleware<ConventionalMiddleware>();
        //}

        public static IApplicationBuilder UseFactoryActivatedMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FactoryActivatedMiddleware>();
        }
    }
    #endregion
}
