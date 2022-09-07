PriorityQueue<int> PQ1 = new PriorityQueue<int>();
PQ1.enqueue(10, 10);
PQ1.enqueue(20, 20);
PQ1.enqueue(1, 1);
PQ1.enqueue(3, 3);

Console.WriteLine(PQ1.dequeue());
Console.WriteLine(PQ1.dequeue());
Console.WriteLine(PQ1.dequeue());
Console.WriteLine(PQ1.dequeue());
Console.WriteLine(PQ1.dequeue());
Console.WriteLine(PQ1.dequeue());


public class Node<T>
{
    public Node(T data, int priority)
    {
        Data = data;
        Priority = priority;
        Next = null;
    }
    public int Priority { get; set; }
    public T Data { get; set; }
    public Node<T> Next { get; set; }
}
public class PriorityQueue<T>
{
    public PriorityQueue() {
        head = null;
        count = 0;
    }

    Node<T> head; // голова
    int count;  

    public int Count { get { return count; } }
    public bool IsEmpty { get { return count == 0; } }

    public void enqueue(T data, int priority)
    {
        Node<T> node = new Node<T>(data, priority);
        Node<T> curNode, prevNode;

        if (head == null)
        {
            // список пуст
            head = node;
        }
        else
        {
            // ищем место для нового элемента
            curNode = head;
            prevNode = curNode;
            while (curNode.Priority > priority)
            {
                prevNode = curNode;
                curNode = prevNode.Next;
                if (curNode == null) break;
            }
            if (curNode == head)
            {
                node.Next = head;
                head = node;
            }
            else
            {
                prevNode.Next = node;
                node.Next = curNode;
            }
    
        }
        count++;
    }

    public T dequeue()
    {
        if (count > 0)
        {
            Node<T> curNode;
            curNode = head;
            if(--count>0) head = curNode.Next;
            return curNode.Data;
        }
        else
        {
            return default(T);
        }
    }
}