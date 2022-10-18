namespace MTSTestTasks.Fourth;

internal class FactorSortedList
{
    public FactorSortedList(int sortFactor)
    {
        SortFactor = sortFactor;
    }

    private Node First { get; set; }

    private readonly int SortFactor;

    int currentMax;

    bool isInitialized = false;

    public IEnumerable<int> InsertAndTake(int item)
    {
        if (!isInitialized)
        {
            Insert(item);
            isInitialized = true;
            currentMax = item;
        }
        else if (item <= currentMax)
            Insert(item);
        else
        {
            currentMax = item;
            int controlValue = item - SortFactor;

            var currentNode = First;
            while(currentNode != null)
            {
                if (currentNode.Value <= controlValue)
                    yield return currentNode.Value;
                else
                    break;

                currentNode = currentNode.Next;
            }
            First = currentNode;

            Insert(item);
        }
    }

    public IEnumerable<int> Take()
    {
        var currentNode = First;
        while(currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    private void Insert(int value)
    {
        if (First == null)
        {
            First = new Node(value);
            return;
        }

        if (First.Next == null)
            if (First.Value > value)
                First = new Node(value) { Next = First };
            else
                First.Next = new Node(value);
        else
        {
            var currentNode = First;
            while (currentNode.Next != null)
            {
                if (currentNode.Next.Value > value)
                    break;
                currentNode = currentNode.Next;
            }

            var newNode = new Node(value) { Next = currentNode.Next };
            currentNode.Next = newNode;
        }
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
