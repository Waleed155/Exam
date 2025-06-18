using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exam.ViewModels
{
    public class ResultViewModel<T>
    {
        public bool success { get; set; }
        public T? Result { get; set; }
        public string ?Message { get; set; }
        public ErrorCode errorCode {  
            get; set; }
        public static ResultViewModel<T> Success(T Data)
        {
            return new ResultViewModel<T>()
            {
                success = true,
                Result = Data,
                Message = "done",
                errorCode = ErrorCode.Success
            };


        }
        public static ResultViewModel<T> Add(T data)
        {
            return new ResultViewModel<T>()
            { success = true, Result = data, Message = "done", errorCode = ErrorCode.created };


        }
        public static ResultViewModel<T> Failure(string message, ErrorCode error=ErrorCode.notexist)
        {
            return new ResultViewModel<T>
            {
                Message = message,
                errorCode = error,
                success = false,

            };
        }
        public enum ErrorCode
        {
            Success = 200,
            created = 201,
            BadReequest = 400,
            unauthorized = 401,
            notexist = 404,
            serverError = 500

        }
    }
}

