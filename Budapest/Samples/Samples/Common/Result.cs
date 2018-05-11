namespace KadGen.Functional.Common
{
    public abstract class BaseResult
    {
        protected BaseResult(ErrorBase error) : this(false)
        {
            Error = error;
        }

        protected BaseResult(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }

        public bool IsSuccessful { get; }
        public ErrorBase Error { get; }

        public static TResult GetErrorResult<TResult>(ErrorBase error) =>
             ReflectionHelpers.CreateInstanceWithPublicOrNonPublicConstructor<TResult>(error);
    }

    public class Result : Result<VoidType>
    {
        internal Result(ErrorBase error) : base(error)
        { }
    }

    public class Result<TData> : BaseResult
    {
        internal Result(ErrorBase error) : base(error)
        { }

        internal Result(TData data) : base(true)
        {
            Data = data;
        }

        public TData Data { get; }

        public static implicit operator Result<TData>(ErrorBase error) => new Result<TData>(error);
        public static implicit operator Result<TData>(TData data) => new Result<TData>(data);

        public Result<string> Foo()
        {
            return "H";
        }



    }
}
