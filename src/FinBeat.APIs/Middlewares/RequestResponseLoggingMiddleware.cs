using FinBeat.Application.Services.Logging;

namespace FinBeat.APIs.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IRequestResponseLogService logService)
        {
            var correlationId = Guid.NewGuid();

            await logService.LogRequestAsync(context, correlationId);

            var originalResponseBodyStream = context.Response.Body;
            using (var responseBodyStream = new MemoryStream())
            {
                context.Response.Body = responseBodyStream;

                await _next(context);

                await logService.LogResponseAsync(context, responseBodyStream, correlationId);

                await responseBodyStream.CopyToAsync(originalResponseBodyStream);
            }
        }
    }
}
