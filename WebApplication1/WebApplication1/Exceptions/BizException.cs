/************************************************************************************************************
* file    : BizException.cs
* author  : cbg
* function: 
* history : 2019-08-29
************************************************************************************************************/

using System;
namespace WebApplication1.Exceptions
{
    /// <summary>
    /// 业务异常
    /// </summary>
    public class BizException : Exception
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrorCode { get; }
        /// <summary>
        /// 业务提示文本
        /// </summary>
        public string ErrorText { get; }

        /// <summary>
        /// 创建BizException对象
        /// </summary>
        /// <param name="errorCode">自定义错误码</param>
        /// <param name="errorText">自定义错误描述</param>
        /// <param name="exception"></param>
        public BizException(string errorText, Exception exception, int errorCode = 99999)
        {
            ErrorCode = errorCode;
            ErrorText = errorText;
            if (errorText == null && exception != null)
            {
                ErrorText = exception.Message;
            }
        }

        /// <summary>
        /// 创建BizException对象
        /// </summary>
        /// <param name="errorCode">自定义错误码</param>
        /// <param name="errorText">自定义错误描述</param>
        public BizException(string errorText, int errorCode = 99999)
        {
            ErrorCode = errorCode;
            ErrorText = errorText;
        }
    }
}

//[Obsolete("过期的方法警告提醒说明")]
//: base(exceptionMessage, exception)