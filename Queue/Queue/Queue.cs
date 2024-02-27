namespace Queue;
public class QueueOfInts : IQueue<int>
{
    // public List<int> queueList = new List<int>() { get; }
    public List<int> queueList = new List<int>();
    public void Enqueue(int queueItem)
    {
        queueList.Add(queueItem);
    }
    public int Dequeue()
    {
        if (queueList.Count == 0)
        {
            throw new InvalidOperationException("No element in the queue");
        }
        var firstElement = queueList[0];
        queueList.RemoveAt(0);
        return firstElement;
    }
    public int Peek()
    {
        if (queueList.Count == 0)
        {
            throw new InvalidOperationException("No element in the queue");
        }
        return queueList[0];
    }
}