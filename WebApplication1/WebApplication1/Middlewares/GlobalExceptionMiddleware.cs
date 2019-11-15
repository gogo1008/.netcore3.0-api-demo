
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Linq;
using WebApplication1.Exceptions;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Middlewares
{
    /// <summary>
    /// 全局异常处理中间件
    /// </summary>
    public class GlobalExceptionMiddleware
    {
        /// <summary>
        /// 系统配置信息
        /// </summary>
        private readonly IConfiguration _configuration;
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        public GlobalExceptionMiddleware(RequestDelegate next, IWebHostEnvironment env, ILogger<GlobalExceptionMiddleware> logger, IConfiguration configuration)
        {
            _next = next;
            _env = env;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex.ToString());
            var result = new ErrorMessage();
            var error = new ErrorMessageContent(context); ;
            if (ex is BizException globalException)
            {
                //如果是自定义异常，则不做处理
                error.ErrorCode = globalException.ErrorCode;
                error.ErrorText = globalException.ErrorText;
                error.Message = $"{globalException.Message}";

                if (globalException.InnerException != null)
                    error.Message = $"{error.Message}，{globalException.InnerException.Message}";
            }
            else
            {
                error.ErrorCode = 500;// ErrorCodeConst.HTTP_16500.ErrorCode;
                error.ErrorText = ex.Message;
                error.Message = ex.Message;
            }

            var debug = context.Request.Query["debug"].ToString();

            bool isDev = _env.EnvironmentName.Contains("dev",StringComparison.OrdinalIgnoreCase);

            error.Stack = (isDev || (!isDev && debug.Equals(bool.TrueString, StringComparison.OrdinalIgnoreCase))) ? ex.StackTrace : null;
            error.Help = _configuration.GetValue<string>("help:error");
            result.Error = error;

            //记日志
            //var error = new ErrorMessageContent(context);
            //int sysId = 1;
            //string ip = context.Connection.RemoteIpAddress.ToString();
            //logger.LogError($"系统编号：{sysId},主机IP:{ip},堆栈信息：{e.StackTrace},异常描述：{e.Message}");
            string json = System.Text.Json.JsonSerializer.Serialize(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}