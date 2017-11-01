namespace KadGen.Common
{ 
    public interface IDomain<TPKey>
    {
        TPKey Id { get; }
    }
}