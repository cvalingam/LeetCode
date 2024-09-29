public class Node
{
    public int count;
    public HashSet<string> keys = new HashSet<string>();
    public Node prev = null;
    public Node next = null;

    public Node(int count)
    {
        this.count = count;
    }

    public Node(int count, string key)
    {
        this.count = count;
        keys.Add(key);
    }
}

public class AllOne
{

    private Dictionary<string, Node> keyToNode = new Dictionary<string, Node>();
    private Node head = new Node(0);
    private Node tail = new Node(0);

    public AllOne()
    {
        head.next = tail;
        tail.prev = head;
    }

    public void Inc(string key)
    {
        if (keyToNode.ContainsKey(key))
            IncrementExistingKey(key);
        else
            AddNewKey(key);
    }

    public void Dec(string key)
    {
        // It is guaranteed that key exists in the data structure before the
        // decrement.
        DecrementExistingKey(key);
    }

    public string GetMaxKey()
    {
        return tail.prev == head ? "" : tail.prev.keys.Last();
    }

    public string GetMinKey()
    {
        return head.next == tail ? "" : head.next.keys.First();
    }

    // Adds a new node with frequency 1.
    private void AddNewKey(string key)
    {
        if (head.next.count == 1)
            head.next.keys.Add(key);
        else
            InsertAfter(head, new Node(1, key));
        keyToNode[key] = head.next;
    }

    // Increments the frequency of the key by 1.
    private void IncrementExistingKey(string key)
    {
        Node node = keyToNode[key];
        node.keys.Remove(key);

        if (node.next == tail || node.next.count > node.count + 1)
            InsertAfter(node, new Node(node.count + 1));

        node.next.keys.Add(key);
        keyToNode[key] = node.next;

        if (node.keys.Count == 0)
            Remove(node);
    }

    // Decrements the count of the key by 1.
    private void DecrementExistingKey(string key)
    {
        Node node = keyToNode[key];
        node.keys.Remove(key);

        if (node.count > 1)
        {
            if (node.prev == head || node.prev.count != node.count - 1)
                InsertAfter(node.prev, new Node(node.count - 1));
            node.prev.keys.Add(key);
            keyToNode[key] = node.prev;
        }
        else
        {
            keyToNode.Remove(key);
        }

        if (node.keys.Count == 0)
            Remove(node);
    }

    private void InsertAfter(Node node, Node newNode)
    {
        newNode.prev = node;
        newNode.next = node.next;
        node.next.prev = newNode;
        node.next = newNode;
    }

    private void Remove(Node node)
    {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }
}