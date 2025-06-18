using Microsoft.EntityFrameworkCore;

namespace Exam.MiddleWare
{
    public class TransactionMiddleWare
    {
        RequestDelegate _next;
        public TransactionMiddleWare(
        RequestDelegate next) { 
            _next=next;
        }
        public async Task Invoke(HttpContext httpContext,DbContext _dbContext)
        
        {
            if (httpContext.Request.Method == "GET")
            {

                await _next(httpContext);
            }
            else { 
            
         await using   var    transaction= await _dbContext.Database.BeginTransactionAsync();
                try
                {
                    await _next(httpContext);
                  await  transaction.CommitAsync();

                }
                catch (Exception ex) {
               await transaction.RollbackAsync();
                    throw;
                    
                }
            }


        }
    }
}
