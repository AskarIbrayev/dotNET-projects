namespace Queue;
internal class Program
{
    public static void Main()  
    {
        var queue = new QueueOfInts();
        queue.Enqueue(5);
        queue.Enqueue(8);
        queue.Enqueue(3);
        var firstElement = queue.Dequeue();
        Console.WriteLine(firstElement);
        Console.WriteLine(queue.Peek());
    } 
}
