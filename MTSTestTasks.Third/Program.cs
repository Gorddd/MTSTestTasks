class Program
{
    public static void Main()
    {
        var collection = new[] { 1, 2, 3, 4, 5, 6, 7, 8 }.EnumerateFromTail(5);

        foreach (var item in collection)
            Console.Write($"({item.item}, {item.tail}) ");
    }
}

static class Extension
{
    /* Решение только с одним перебором значений невозможно, 
     * т.к IEnumerable позволяет обходить коллекцию только с начала 
     * и не содержит свойства Count, как например ICollection */
    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
    {
        var length = enumerable.Count(); //Первый проход по коллекции

        if (length < tailLength || tailLength < 0)
            throw new ArgumentOutOfRangeException
                ($"{nameof(tailLength)} can't be greater than number of elements in {nameof(enumerable)} or less than 0");

        int index = 0,
            startIndex = length - (tailLength ?? 0),
            countedValue = (int)tailLength - 1;

        foreach (var item in enumerable) //Второй проход по коллекции
        {
            if (index >= startIndex)
            {
                yield return (item, countedValue);
                countedValue--;
            }
            else
                yield return (item, null);

            index++;
        }
    }
}