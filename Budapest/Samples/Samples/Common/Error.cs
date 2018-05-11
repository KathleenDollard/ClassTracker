using System;
using System.Collections.Generic;

namespace KadGen.Functional.Common
{
    public abstract class ErrorBase
    { }

    public class ExceptionFail : ErrorBase
    {
        public ExceptionFail(Exception ex)
        {
            Exception = ex;
        }
        public Exception Exception { get; }
    }

    public class ValidationFail : ErrorBase
    {
        public IEnumerable<ValidationIssue> ValidationIssues { get; }
            = new List<ValidationIssue>();
    }

    public class BatchFail : ErrorBase
    {
        // TODO
    }
}