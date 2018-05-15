using static KadGen.Functional.Common.Constants;

namespace KadGen.Functional.Common
{
    public abstract class BaseRichData
    {
        protected BaseRichData(OutcomeAndIssues issueBase) : this(issueBase.Outcome)
        => IssueBase = issueBase;

        protected BaseRichData(Outcome outcome)
        => Outcome = outcome;

        public Outcome Outcome { get; }
        public OutcomeAndIssues IssueBase { get; }

        public static TRichData GetErrorRichData<TRichData>(OutcomeAndIssues error)
        => ReflectionHelpers.CreateInstanceWithPublicOrNonPublicConstructor<TRichData>(error);
    }

    public class RichData : RichData<VoidType>
    {
        private RichData(OutcomeAndIssues issueBase)
        : base(issueBase, VoidData) { }

        private RichData(Outcome outcome)
        : base(outcome, VoidData) { }

        public static RichData Success()
        => new RichData(Constants.Success);

        public static RichData Warning(WarningOutcome issueBase)
        => new RichData(issueBase);

        public static RichData Info(WarningOutcome issueBase)
        => new RichData(issueBase);

        public static RichData Error(ErrorOutcome issueBase)
        => new RichData(issueBase);
    }

    public class RichData<TData> : BaseRichData
    {
        internal RichData(Outcome outcome, TData data) : base(outcome)
        => Data = data;

        internal RichData(OutcomeAndIssues issueBase, TData data) : base(issueBase)
        => Data = data;

        public TData Data { get; }

        public static RichData<TData> Success(TData data)
        => new RichData<TData>(Constants.Success, data);

        public static RichData<TData> Warning(OutcomeAndIssues issueBase, TData data)
        => new RichData<TData>( issueBase, data);

        public static RichData<TData> Info(OutcomeAndIssues issueBase, TData data)
        => new RichData<TData>( issueBase, data);

        public static RichData<TData> Error(OutcomeAndIssues issueBase, TData data)
        => new RichData<TData>( issueBase, data);

        public static implicit operator RichData<TData>(ErrorOutcome error)
        => new RichData<TData>( error, default);

        public static implicit operator RichData<TData>((WarningOutcome Warning, TData Data) tuple)
         => new RichData<TData>(tuple.Warning, tuple.Data);

        public static implicit operator RichData<TData>((InfoOutcome Info, TData Data) tuple)
         => new RichData<TData>(tuple.Info, tuple.Data);

        public static implicit operator RichData<TData>(TData data)
        => new RichData<TData>(Constants.Success,  data);
    }
}
