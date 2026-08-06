using BookStoreAPI.Models;

namespace BookStoreAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync (HttpContext context)
        {
            //await _next(context); //I'm done with my work. Now pass this request to the next middleware.
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private static async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json"; //The response I'm sending is JSON
            context.Response.StatusCode = ex switch
            {
                ArgumentException => StatusCodes.Status400BadRequest,

                KeyNotFoundException => StatusCodes.Status404NotFound,

                InvalidOperationException => StatusCodes.Status409Conflict,

                _ => StatusCodes.Status500InternalServerError
            };
            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            };
            //We're creating an object that will become JSON.
            //    It will look like:

            //  {
            //    "statusCode": 500,
            //  "message": "Database is down"
            //   }

            await context.Response.WriteAsJsonAsync(response);
            //This converts the object into JSON and sends it back to the client
        }
    }
}
