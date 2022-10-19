namespace MTSTestTasks.Fourth;

class Program
{
    public static void Main()
    {
        var collection = Sort2(new[] { 4, 3, 9, 7, 8, 9, 10, 14 }, 4);
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

    public static IEnumerable<int> Sort2(IEnumerable<int> inputStream, int sortFactor)
    {
        var dict = new Dictionary<int, int>();
        int minNotReturned = 0;
        int maxItem = -1;

        foreach (var item in inputStream)
        {
            if (!dict.ContainsKey(item))
                dict.Add(item, 1);
            else
                dict[item]++;

            if (item > maxItem)
                maxItem = item;

            var maxToReturn = item - sortFactor;
            while (minNotReturned < maxToReturn)
            {
                if (dict.ContainsKey(minNotReturned))
                {
                    while (dict[minNotReturned] > 0)
                    {
                        yield return minNotReturned;
                        dict[minNotReturned]--;
                    }
                }
                minNotReturned++;
            }
        }

        while (minNotReturned <= maxItem)
        {
            if (dict.ContainsKey(minNotReturned))
            {
                while (dict[minNotReturned] > 0)
                {
                    yield return minNotReturned;
                    dict[minNotReturned]--;
                }
            }
            minNotReturned++;
        }
    }
}