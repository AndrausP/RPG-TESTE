using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_TESTE.Domain.UnifiedResponse
{
    public class Result<T> : IActionResult
    {
        public bool IsSuccess { get; init; }
        public T Data { get; init; }
        public string Error { get; init; }
        public int StatusCode { get; init; } = 200; // default 200
        public static Result<T> Success(T data, int statusCode = 200) =>
            new() { IsSuccess = true, Data = data, StatusCode = statusCode };
        public static Result<T> Failure(string error, int statusCode = 400) =>
            new() { IsSuccess = false, Error = error, StatusCode = statusCode };
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(this)
            {
                StatusCode = StatusCode
            };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}
