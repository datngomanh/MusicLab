using Microsoft.AspNetCore.Diagnostics;
using MusicLab.Repository.Models.ResponseModel;

namespace MusicLab.Backend.Middleware
{
    public static class ExceptionHandlerMiddleware
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response
                            .WriteAsJsonAsync(new CustomErrorResponseModel(500, "Internal Server Error", null))
                            .ConfigureAwait(false);
                    }
                });
            });

        }
    }
}
