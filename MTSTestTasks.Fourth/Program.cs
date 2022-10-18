namespace MTSTestTasks.Fourth;

class Program
{
    public static void Main()
    {
        var collection = Sort(new[] { 1, 0, 4, 6, 2, 8, 5 }, 4, 8);
        foreach (var item in collection)
        {
            Console.Write(item + " ");
        }
    }

    public static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        var linkedList = new FactorSortedList();
        foreach (var item in inputStream)
        {
            
        }
        
    }

    private static void InsertInSortedLinkedList(LinkedList<int> linkedList, int value)
    {
        LinkedListNode<int> currentNode = linkedList.First;
        if (currentNode == null)
        {
            linkedList.AddLast(value);
            return;
        }

        while(currentNode != null)
        {
            if (currentNode.Value > value)
                break;
            currentNode = currentNode.Next;
        }

        linkedList.AddBefore(currentNode, value);
    }
}