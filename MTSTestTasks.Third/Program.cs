class Program
{
    public static void Main()
    {
        var collection = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }.EnumerateFromTail(5);

        foreach (var item in collection)
            Console.Write($"({item.item}, {item.tail}) ");
    }
}

static class Extension
{
    /* Решение только с одним перебором значений возможно лишь при tailLength = 0, 
     * т.к IEnumerable позволяет обходить коллекцию только с начала 
     * и не содержит свойства Count, как например ICollection */
    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
    {
        int length = 0;

        tailLength = tailLength ?? 0;
        if (tailLength != 0)
            length = enumerable.Count(); //Первый проход по коллекции
        
        Validate(tailLength, length);

        int index = 0,
            startIndex = length - (tailLength ?? 0),
            countedValue = (int)tailLength - 1;

        foreach (var item in enumerable) //Второй проход по коллекции
        {
            if (tailLength != 0 && index >= startIndex)
            {
                yield return (item, countedValue);
                countedValue--;
            }
            else
                yield return (item, null);

            index++;
        }
    }

    private static void Validate(int? tailLength, int collectionLength)
    {
        if (collectionLength < tailLength || tailLength < 0)
            throw new ArgumentOutOfRangeException
                ($"{nameof(tailLength)} can't be greater than number of elements in collection or less than 0");
    }
}