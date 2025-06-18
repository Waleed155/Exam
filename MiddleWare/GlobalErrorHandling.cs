using Exam.ViewModels;

namespace Exam.MiddleWare
{
    public class GlobalErrorHandling
    {
        RequestDelegate _next;
       
        public GlobalErrorHandling(RequestDelegate next) { _next = next; }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

            }
            catch (Exception ex)
            {
                File.WriteAllTextAsync("G:\\log1.txt", ex.Message);
            }
        }
    }
}
