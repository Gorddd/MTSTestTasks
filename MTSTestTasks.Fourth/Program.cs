namespace MTSTestTasks.Fourth;

class Program
{
    public static void Main()
    {
        var collection = Sort(new[] { 3, 2, 1, 0, 7 }, 3);
        foreach (var item in collection)
        {
            Console.Write(item + " ");
        }
    }

    /* Оптимально по памяти: O(n) в худшем случае, зависит от sortFactor, чем меньше тем чаще освобождается
     * Оптимально по времени: O(n^2) в худшем случае, зависит от частоты встречи элемента большего всех остальных */
    public static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor)
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
                    dict.Remove(minNotReturned); //O(1)
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