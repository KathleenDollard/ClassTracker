namespace KadGen.Common
{ 
    public interface IDomain<TPKey>
        where TPKey : struct
    {
        TPKey Id { get; }
    }
}