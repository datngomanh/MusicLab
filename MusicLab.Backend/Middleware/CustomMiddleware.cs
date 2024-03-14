using MusicLab.Repository.Models.ResponseModel;
using Newtonsoft.Json;

namespace MusicLab.Backend.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;

        public CustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "application/json";
                // Init a new stream for the body
                var originalBodyStream = context.Response.Body;
                
                // Call the next middleware in the pipeline
                await next(context).ConfigureAwait(true);

                if (context.Response.StatusCode == 400)
                {
                    context.Response.Body = new MemoryStream();
                    context.Response.Body.Seek(0, SeekOrigin.Begin);
                    var modifiedResponse = await new StreamReader(context.Response.Body).ReadToEndAsync();
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponseModel>(modifiedResponse);
                    var errors = errorResponse.Errors;

                    // Modify the response content
                    context.Response.Body = originalBodyStream;
                    await context.Response.WriteAsJsonAsync(new CustomErrorResponseModel(400, "Bad Request", errors))
                                .ConfigureAwait(false);
                }
                if (context.Response.StatusCode == 401)
                {
                    await context.Response.WriteAsJsonAsync(new CustomErrorResponseModel(401, "Unauthorized", null))
                                .ConfigureAwait(false);
                }
               
                //if other cases here
            }
            catch (Exception ex)
            {
            }
        }
    }
}
