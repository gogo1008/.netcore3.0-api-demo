/************************************************************************************************************
* file    : ErrorMessage.cs
* author  : cbg
* function: 
* history : 2018-11-03
************************************************************************************************************/

namespace WebApplication1.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorMessage 
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Success { get; private set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public object Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ErrorMessageContent Error { get; set; }
    }
}