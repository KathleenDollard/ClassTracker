using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using static KadGen.Functional.Common.Constants;

namespace KadGen.Functional.Common
{
    public abstract class OutcomeAndIssues
    {
        // Expected use is to create a new RichData with the union of previous and new issues
        protected OutcomeAndIssues(IEnumerable<IssueBase> issues)
           => Issues = issues.ToImmutableList();

        protected OutcomeAndIssues(params IssueBase[] issues)
          => Issues = issues.ToImmutableList();

        public abstract Outcome Outcome { get; }

        public ImmutableList<IssueBase> Issues { get; }
    }

    #region Error classes
    public abstract class ErrorOutcome : OutcomeAndIssues
    {
        protected ErrorOutcome(IEnumerable<IssueBase> issues)
        : base(issues) { }

        protected ErrorOutcome(params IssueBase[] issues)
        : base(issues) { }

        private static readonly Outcome outcome = Fail;
        public override Outcome Outcome
        => outcome;
    }

    public class ExceptionFail : ErrorOutcome
    {
        public ExceptionFail(Exception ex)
        => new ExceptionIssue(ex);
    }

    public class ValidationFail : ErrorOutcome
    {
        public IEnumerable<ValidationIssue> ValidationIssues { get; }
            = new List<ValidationIssue>();
    }

    public class BatchFail : ErrorOutcome
    {
        // TODO
    }
    #endregion

    public abstract class IssueBase
    {
        public abstract string UserMessage { get; }      // must be capable of giving a user message
        public virtual string LogMessage => UserMessage; // may also provide a programmer message
    }

    public class StringIssue : IssueBase
    {
        public StringIssue(string issue)
        => UserMessage = issue;

        public override string UserMessage { get; }
    }

    public class ExceptionIssue : IssueBase
    {
        public readonly static string ExceptionHappened = "Oops"; // suggest you work a bit harder here
        public ExceptionIssue(Exception ex)
        => Exception = ex;

        public ExceptionIssue(Exception ex, string userMessage)
        => Exception = ex;

        public Exception Exception { get; }

        public override string UserMessage
        => ExceptionHappened;

        public override string LogMessage
        => Exception.ToString();
    }

    #region Warning classes
    // Warnings and Info are different because I kept thinking of the 
    // Visual Studio feature "Treat warnings as errors" and wanted outer
    // infrastructure to be able to do something like that
    public class WarningOutcome : OutcomeAndIssues
    {
        protected WarningOutcome(IEnumerable<IssueBase> issues)
         : base(issues) { }

        private static readonly Outcome outcome = Success;
        public override Outcome Outcome
        => outcome;
    }
    #endregion

    #region Info classes
    public class InfoOutcome : OutcomeAndIssues
    {
        protected InfoOutcome(IEnumerable<IssueBase> issues)
        : base(issues) { }

        private static readonly Outcome outcome = Success;
        public override Outcome Outcome
        => outcome;

        // Probably want to add verbosity, which means either multiple classes
        // or, more likely, a parameterized constructor here. 
    }
    #endregion

}