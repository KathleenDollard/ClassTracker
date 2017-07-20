using System;
using System.Collections.Generic;
using System.Linq;

namespace KadGen.Common
{
    public class Result
    {
        internal Result(IEnumerable<Error> errors,
                IEnumerable<ValidationIssue> validationIssues)
        {
            Errors = errors ?? new List<Error>();
            ValidationIssues = validationIssues ?? new List<ValidationIssue>();
            IsSuccessful = !Errors.Any() && !ValidationIssues.Any();
        }

        public bool IsSuccessful { get; }
        public IEnumerable<Error> Errors { get; }
        public IEnumerable<ValidationIssue> ValidationIssues { get; }

        public static TResult CreateSuccessResult<TResult>()
                     where TResult : Result
                => ReflectionHelpers
                     .CreateInstanceWithPublicOrNonPublicConstructor<TResult>(null, null);

        public static TResult CreateErrorResult<TResult>(params Error[] errors)
                where TResult : Result
            => ReflectionHelpers
                .CreateInstanceWithPublicOrNonPublicConstructor<TResult>(errors, null);

        public static TResult CreateValidationIssueResult<TResult>(params ValidationIssue[] validationIssues)
                where TResult : Result
          => ReflectionHelpers
                .CreateInstanceWithPublicOrNonPublicConstructor<TResult>(null, validationIssues);
    }
}
