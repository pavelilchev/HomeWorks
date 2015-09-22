
public class LinkedList<T>
{
    private ListNode<T> head;

    private int count;

    public LinkedList()
    {
    }


    public ListNode<T> FirstElement
    {
        get
        {
            return head;
        }
    }

    public int Count { get { return count; } }

    public void Add(T element)
    {
        if (Count > 0)
        {

        }
        if (Count == 0)
        {
            firstElement.Element = element;
            Count++;
        }

    }
}

