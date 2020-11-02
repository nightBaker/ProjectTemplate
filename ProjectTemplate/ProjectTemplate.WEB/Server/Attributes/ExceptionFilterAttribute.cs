using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectTemplate.APPLICATION.Dtos.Exceptions;


namespace ProjectTemplate.WEB.Server.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionFilterAttribute : Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    {
        private readonly ILogger _logger;
        private JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
        };
        public ExceptionFilterAttribute(ILogger<ExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }
        public override Task OnExceptionAsync(ExceptionContext context)
        {

            switch (context.Exception)
            {
                case SomeException someException:                   
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict; //just as example
                    _logger.LogError(context.Exception, nameof(SomeException));
                    break;
               
                default:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    _logger.LogError(context.Exception, "unhandled exception");
                    break;
            }

            context.HttpContext.Response.ContentType = "application/json";
            return context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(context.Exception, _settings));
        }
    }
}
