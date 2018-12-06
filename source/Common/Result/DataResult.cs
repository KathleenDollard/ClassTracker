using System;
using System.Collections.Generic;

namespace KadGen.Common
{
    public class DataResult<TData> : Result
    {
        internal DataResult(
                TData data,
                IEnumerable<Error> errors,
                IEnumerable<ValidationIssue> validationIssues)
            : base(errors, validationIssues)
        => Data = data;

        internal DataResult(
                  Error[] errors,
                  IEnumerable<ValidationIssue> validationIssues)
              : base(errors, validationIssues) 
        => Data = default(TData);

        public static DataResult<TData> CreateSuccessResult(TData data) 
        => new DataResult<TData>(data, null, null);

        public DataResult<TNewType> CreateWithMap<TNewType>(
                Func<TData, TNewType> map) 
        => new DataResult<TNewType>(map(Data),
                Errors, ValidationIssues);

        public TData Data { get; }

    }
}
