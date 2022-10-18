namespace MTSTestTasks.Fourth;

internal class FactorSortedList
{
    private Node First { get; set; }

    private Node Last { get; set; }

    private int currentMax;

    public IEnumerable<int> InsertAndTake(int item)
    {
        if (item <= currentMax)
            Insert(item);
        else
        {
            int offset = item - currentMax;

            foreach (var itemToReturn in Take(offset))
                yield return itemToReturn;

            Insert(item);
        }
    }

    private void Insert(int value)
    {
        if (First == null)
        {
            First = Last = new Node(value);
            return;
        }

        var currentNode = First;
        while (currentNode.Next != null)
        {
            if (currentNode.Next.Value > value)
                break;
            currentNode = currentNode.Next;
        }

        var newNode = new Node(value) { Next = currentNode.Next };
        currentNode.Next = newNode;
        
        if (Last == currentNode)
            Last = newNode;
    }

    private IEnumerable<int> Take(int amount)
    {
        var currentNode = First;
        for (int i = 0; i < amount && currentNode != null; i++)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
        First = currentNode;
    }

    class Node
    {
        public int Value { get; set; }

        public Node(int value)
        {
            Value = value;
        }

        public Node Next { get; set; } = null!;
    }
}
