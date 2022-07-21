namespace Rules8x8
{
    public interface IStrategyRule<T1, T2, T3, T4>
    {
        T1 Filter1 { get;set;}
        T2 Filter2 { get;set;}
        T3 Filter3 { get;set;}
        T4 Filter4 { get;set;}
    }
}