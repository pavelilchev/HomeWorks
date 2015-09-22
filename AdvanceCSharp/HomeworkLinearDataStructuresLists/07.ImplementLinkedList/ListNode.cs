
public class ListNode<T>
{
    public ListNode(T element)
    {
        this.Element = element;
        this.NextElement = default(T);
    }

    public T Element { get; set; }

    public T NextElement { get; set; }

}

