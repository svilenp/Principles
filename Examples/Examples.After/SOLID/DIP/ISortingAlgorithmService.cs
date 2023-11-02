namespace Examples.After.SOLID.DIP;

public interface ISortingAlgorithmService
{
    void Sort<T>(T[] array) where T : IComparable<T>;
}
