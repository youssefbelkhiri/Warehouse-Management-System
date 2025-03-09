using Serilog.Context;

namespace Backend.Api.Middleware
{
    public class RequestLogContextMidlleware
    {
        private readonly RequestDelegate _next;
        public RequestLogContextMidlleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            using (LogContext.PushProperty("CorrelationID" , context.TraceIdentifier))
            {
                return _next(context);
            }
        }
    }
}
