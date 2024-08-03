public class LRUCache
{
    private int capacity;
    private Node head = new Node(0, 0), tail = new Node(0, 0);
    private Dictionary<int, Node> map = new Dictionary<int, Node>();

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        head.next = tail;
        tail.prev = head;
    }

    public int Get(int key)
    {
        if (!map.ContainsKey(key))
            return -1;

        Node node = map[key];
        remove(node);
        insert(node);
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (map.ContainsKey(key))
            remove(map[key]);

        if (map.Count == capacity)
            remove(tail.prev);

        insert(new Node(key, value));
    }

    private void remove(Node node)
    {
        map.Remove(node.Key);
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }

    private void insert(Node node)
    {
        map.Add(node.Key, node);
        node.next = head.next;
        node.next.prev = node;
        head.next = node;
        node.prev = head;
    }
}

class Node
{
    public int Key;
    public int Value;
    public Node prev, next;
    public Node(int key, int value)
    {
        this.Key = key;
        this.Value = value;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */