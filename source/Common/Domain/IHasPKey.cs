namespace Common.Domain
{
    // Used to check type consistency for IDomain<TPkey>
    public interface IHasPKey
    {
    }

    public interface IHasPKey<TPKey> : IHasPKey
    {
        TPKey GetPKey();
    }
}
