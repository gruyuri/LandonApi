using LandonApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment env;

        public JsonExceptionFilter(IHostingEnvironment env)
        {
            this.env = env;
        }
        public void OnException(ExceptionContext context)
        {
            var error = new ApiError()
            {
                Message = context.Exception.Message,
                Detail = context.Exception.StackTrace
            };

            if (!env.IsDevelopment())
            {
                error.Message = "A server error occured.";
                error.Detail = context.Exception.Message;
            }

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
