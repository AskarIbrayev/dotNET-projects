using System;
namespace Queue;

public class QueueUnitTests
{
    [Fact]
    public void Integer_Is_Added_To_The_Queue()
    {
        var queue = new QueueOfInts();

        queue.Enqueue(1);

        Assert.Contains(1, queue.queueList);
    }

    [Fact]
    public void First_Item_Of_Queue_Is_Dequeued()
    {
        var queue = new QueueOfInts();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        var firstItemBeforeDequeue = queue.queueList[0];

        var dequeuedItem = queue.Dequeue();

        Assert.Equal(dequeuedItem, firstItemBeforeDequeue);
        Assert.NotEqual(queue.queueList[0], firstItemBeforeDequeue);
    }

    [Fact]
    public void Fist_Item_Of_Queue_Is_Peeked()
    {
        var queue = new QueueOfInts();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        var peekedItem = queue.Peek();

        Assert.Equal(peekedItem, queue.queueList[0]);
    }
    
    [Fact]
    public void Throw_Exception_For_Dequeueing_When_Queue_Is_Empty()
    {
        var queue = new QueueOfInts();
        
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }
    [Fact]

    public void Throw_Exception_For_Peeking_When_Queue_Is_Empty()
    {
        var queue = new QueueOfInts();
        
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }
}