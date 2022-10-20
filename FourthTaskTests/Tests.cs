using MTSTestTasks.Fourth;

namespace FourthTaskTests;

public class Tests
{
    [Test]
    public void AlreadySorted()
    {
        var collection = new[] { 15, 29, 30, 45, 76 };
        var sortFactor = 10;

        WillSortCollectionsEqual(collection, sortFactor);
    }

    [Test]
    public void WithoutNewMax()
    {
        var collection = new[] { 14, 12, 9, 5, 5, 5, 5 };
        var sortFactor = 9;

        WillSortCollectionsEqual(collection, sortFactor);
    }

    [Test]
    public void OnlyOneValue()
    {
        var collection = new[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        var sortFactor = 100;

        WillSortCollectionsEqual(collection, sortFactor);
    }

    [Test]
    public void LastMaxInTheEnd()
    {
        var collection = new[] { 3, 2, 1, 0, 7 };
        var sortFactor = 3;
        
        WillSortCollectionsEqual(collection, sortFactor);
    }

    [Test]
    public void CloseToSortFactor()
    {
        var collection = new[] { 5, 1, 7, 3, 4, 4, 4, 3, 10, 7, 6 };
        var sortFactor = 4;

        WillSortCollectionsEqual(collection, sortFactor);
    }

    private void WillSortCollectionsEqual(IEnumerable<int> collection, int sortFactor)
    {
        var actualSortedCollection = Program.Sort(collection, sortFactor).ToArray();
        var expectedSortedCollection = collection.OrderBy(item => item).ToArray();
        
        Assert.That(actualSortedCollection.Length, Is.EqualTo(expectedSortedCollection.Length));

        for (int i = 0; i < expectedSortedCollection.Length; i++)
            Assert.That(actualSortedCollection[i], Is.EqualTo(expectedSortedCollection[i]));
    }
}