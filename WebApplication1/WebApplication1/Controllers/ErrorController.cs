using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]        
        public IActionResult Error()=> Problem();

    }
}




//// [Route("/error2")]
//public IActionResult Error1()
//{
//    // return new JsonResult(new { Value = "sss" });
//    var a = HttpContext.Features.Get<IExceptionHandlerFeature>();
//    //// 捕获状态码
//    //var statusCode = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error is HttpResponseException httpEx ?
//    //  httpEx.StatusCode : (HttpStatusCode)Response.StatusCode;
//    return new JsonResult(new { Value = "sss" });
//    //// 如果是ASP.NET Core Web Api 应用程序，直接返回状态码(不跳转到错误页面，这里假设所有API接口的路径都是以/api/开始的)
//    //if (HttpContext.Features.Get<IHttpRequestFeature>().RawTarget.StartsWith("/api/", StringComparison.Ordinal))
//    //    return StatusCode((int)statusCode);

//    //// 创建一个友好的错误处理页面视图模型.
//    //string text = null;
//    //switch (statusCode)
//    //{
//    //    case HttpStatusCode.NotFound: text = "Page not found."; break;
//    //        // 其他详细信息
//    //}
//    //return View("Error", new ErrorViewModel
//    //{
//    //    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
//    //    ErrorText = text
//    //});

//}
////Problem();
