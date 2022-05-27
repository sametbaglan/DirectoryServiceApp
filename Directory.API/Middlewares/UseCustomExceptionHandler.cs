using Directory.Core.Dto.ResponseResult;
using Directory.Core.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace Directory.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionhandler = context.Features.Get<IExceptionHandlerFeature>();
                    var statuscode = exceptionhandler.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        SuccessException => 200,
                        _ => 500
                    };
                    context.Response.StatusCode = statuscode;
                    var errormessage = new List<string>();
                    errormessage.Add(exceptionhandler.Error.Message);
                    var response = Response<NoContentResult>.Fail(errormessage, 400);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
