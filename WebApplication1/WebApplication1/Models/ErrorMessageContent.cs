/************************************************************************************************************
* file    : ErrorMessageContent.cs
* author  : cbg
* function: 
* history : 2018-11-03
************************************************************************************************************/
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Models
{
    /// <summary>
    /// 全局异常信息对象
    /// </summary>
    public class ErrorMessageContent 
    {
        /// <summary>
        /// 当前请求的ID
        /// </summary>
        public string HttpTraceId { get; set; }

        /// <summary>
        /// 请求的Http方法
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public int? HttpStatusCode { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorText { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 堆栈调用路径
        /// </summary>
        public string Stack { get; set; }

        /// <summary>
        /// 说明信息
        /// </summary>
        public string Help { get; set; }

        /// <summary>
        /// 创建错误消息内容
        /// </summary>
        public ErrorMessageContent()
        {
        }

        /// <summary>
        /// 创建错误消息内容
        /// </summary>
        /// <param name="httpContext"><see cref="HttpContext"/></param>
        public ErrorMessageContent(HttpContext httpContext)
        {
            HttpTraceId = httpContext.TraceIdentifier;
            HttpMethod = httpContext.Request.Method;
            HttpStatusCode = httpContext.Response.StatusCode;
        }

        /// <summary>
        /// 创建错误消息内容
        /// </summary>
        /// <param name="httpContext"><see cref="HttpContext"/></param>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorText">错误码描述</param>
        public ErrorMessageContent(HttpContext httpContext, int errorCode, string errorText) : this(httpContext)
        {
            ErrorCode = errorCode;
            ErrorText = errorText;
        }
    }
}