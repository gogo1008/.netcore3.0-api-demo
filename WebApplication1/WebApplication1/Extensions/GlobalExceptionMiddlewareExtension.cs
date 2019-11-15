
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.Middlewares;

namespace WebApplication1.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class GlobalExceptionMiddlewareExtension
    {
        /// <summary>
        /// 全局参数验证，在所有中间件调用之前调用
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGlobalException(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
