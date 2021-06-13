using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Back.Exceptions
{
    public class HttpException : System.Exception
    {
        public List<string> Messages { get; internal set; }

        public HttpStatusCode ErrorCode { get; internal set; }

        public HttpException()
        {
            Messages = new List<string>();
        }

        public HttpException(HttpStatusCode errorCode = HttpStatusCode.InternalServerError) : this()
        {
            ErrorCode = errorCode;
        }

        public HttpException(List<string> messages)
        {
            Messages = messages ?? new List<string>();
        }

        public HttpException(List<string> messages, HttpStatusCode errorCode = HttpStatusCode.InternalServerError)
        {
            Messages = messages ?? new List<string>();
            ErrorCode = errorCode;
        }
    }
}