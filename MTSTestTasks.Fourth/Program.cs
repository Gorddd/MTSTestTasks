namespace MTSTestTasks.Fourth;

class Program
{
    public static void Main()
    {
        var collection = Sort1(new[] { 4, 3, 9, 7, 8, 9, 10, 14 }, 4);
        foreach (var item in collection)
        {
            Console.Write(item + " ");
        }
    }

    public static IEnumerable<int> Sort1(IEnumerable<int> inputStream, int sortFactor)
    {
        var linkedList = new FactorSortedList(sortFactor);
        foreach (var item in inputStream)
            foreach (var itemToReturn in linkedList.InsertAndTake(item))
                yield return itemToReturn;
        foreach (var item in linkedList.Take()) //берем оставшиеся
            yield return item;
    }

}