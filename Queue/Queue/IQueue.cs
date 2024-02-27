namespace Queue;

public interface IQueue<T>
{
    void Enqueue(T value);
    T Dequeue();
    T Peek();
}