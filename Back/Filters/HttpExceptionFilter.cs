using Back.Exceptions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;

namespace Back.Filters
{
    public class HttpExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var error = new HttpException(
                new List<string>() { "Ocurrio un error interno" },
                HttpStatusCode.InternalServerError);

            if (context.Exception is HttpException)
            {
                error = context.Exception as HttpException;
            }
        
            context.Response = context.Request.CreateResponse(
                error.ErrorCode, 
                new ResponseError() { Message = error.Messages }, 
                JsonMediaTypeFormatter.DefaultMediaType
                );

        }

        class ResponseError
        {
            public List<string> Message { get; set; }
        }
    }
}