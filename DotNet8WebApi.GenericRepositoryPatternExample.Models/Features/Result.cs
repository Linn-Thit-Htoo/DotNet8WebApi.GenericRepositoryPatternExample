using DotNet8WebApi.GenericRepositoryPatternExample.Models.Enums;
using DotNet8WebApi.GenericRepositoryPatternExample.Models.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.GenericRepositoryPatternExample.Models.Features
{
    public class Result<T>
    {
        public List<T> Data { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get { return !IsSuccess; } }
        public string Message { get; set; }
        public EnumStatusCode StatusCode { get; set; }
        public static Result<T> SuccessResult(string message = "Success.", EnumStatusCode statusCode = EnumStatusCode.Success)
        {
            return new Result<T> { IsSuccess = true, Message = message, StatusCode = statusCode };
        }
        public static Result<T> SuccessResult(List<T> data, string message = "Success.", EnumStatusCode statusCode = EnumStatusCode.Success)
        {
            return new Result<T> { IsSuccess = true, Message = message, StatusCode = statusCode, Data = data };
        }
        public static Result<T> FailureResult(string message = "Fail.", EnumStatusCode statusCode = EnumStatusCode.BadRequest)
        {
            return new Result<T> { IsSuccess = false, Message = message, StatusCode = statusCode };
        }
        public static Result<T> FailureResult(Exception ex, EnumStatusCode statusCode = EnumStatusCode.InternalServerError)
        {
            return new Result<T> { IsSuccess = false, Message = ex.ToString(), StatusCode = statusCode };
        }
        public static Result<T> ExecuteResult(int result, EnumStatusCode successStatusCode = EnumStatusCode.Success, EnumStatusCode failureStatusCode = EnumStatusCode.BadRequest)
        {
            return result > 0 ? Result<T>.SuccessResult(statusCode: successStatusCode)
                : Result<T>.FailureResult(statusCode: failureStatusCode);
        }
    }
}