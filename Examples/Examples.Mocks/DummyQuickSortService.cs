namespace Examples.Mocks;

public class QuickSortService
{
    public void Sort<T>(T[] array) where T : IComparable<T>
    {
        if (array == null || array.Length <= 1)
            return;

        QuickSort(array, 0, array.Length - 1);
    }

    private void QuickSort<T>(T[] array, int left, int right) where T : IComparable<T>
    {
        if (left < right)
        {
            int partitionIndex = Partition(array, left, right);

            QuickSort(array, left, partitionIndex - 1);
            QuickSort(array, partitionIndex + 1, right);
        }
    }

    private int Partition<T>(T[] array, int left, int right) where T : IComparable<T>
    {
        T pivot = array[right];
        int i = (left - 1);

        for (int j = left; j < right; j++)
        {
            if (array[j].CompareTo(pivot) <= 0)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, right);
        return i + 1;
    }

    private void Swap<T>(T[] array, int i, int j)
    {
        T temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

