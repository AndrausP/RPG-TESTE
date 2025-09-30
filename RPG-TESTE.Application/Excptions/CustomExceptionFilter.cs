using RPG_TESTE.Domain.UnifiedResponse;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;



namespace RPG_TESTE.Application.Excptions
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Result<object> result;
            if (context.Exception is ValidationException validationException)
            {
                var messages = validationException.Errors
                    .Select(e => $"{e.PropertyName}: {e.ErrorMessage}");
                var combinedMessage = string.Join("; ", messages);
                var error = new Error(combinedMessage);
                result = Result<object>.Failure(error);

                context.Result = new JsonResult(result)
                {
                    StatusCode = 400
                };
            }
            else
            {
                var exception = context.Exception;
                var errorMessage = exception.Message;

                var stackTrace = exception.StackTrace;
                var error = new Error(errorMessage);
                result = Result<object>.Failure(error);
                context.Result = new JsonResult(result)
                {
                    StatusCode = 500
                };
                Console.WriteLine($" ERRO: {errorMessage}\n{stackTrace}");
                context.ExceptionHandled = true;
            }
        }
    }
}
