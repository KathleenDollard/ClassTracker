using System;

namespace KadGen.Common
{
    public class Error
    {
        public Error(ErrorCode errorCode, Exception exception, string message )
        {
            ErrorCode = errorCode;
            Exception = exception;
            Message = message;
        }

        public ErrorCode ErrorCode {get;}
        public Exception Exception { get; }
        public string Message { get; }
    }
}
