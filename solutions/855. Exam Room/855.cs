public class Node
{
    public Node prev;
    public Node next;
    public int value;

    public Node(int value)
    {
        this.value = value;
    }
}

public class ExamRoom
{
    int n;
    Node head = new Node(-1);
    Node tail = new Node(-1);
    Dictionary<int, Node> map = new Dictionary<int, Node>();

    public ExamRoom(int n)
    {
        this.n = n;
        Join(head, tail);
    }

    public int Seat()
    {
        if (head.next == tail)
        {
            Node node = new Node(0);
            Join(head, node);
            Join(node, tail);
            map[0] = node;
            return 0;
        }

        int prevStudent = -1;
        int maxDistToClosest = 0;
        int val = 0;
        Node pos = null;

        for (Node node = head; node != tail; node = node.next)
        {
            if (prevStudent == -1)
            {
                maxDistToClosest = node.value;
                pos = node;
            }
            else if ((node.value - prevStudent) / 2 > maxDistToClosest)
            {
                maxDistToClosest = (node.value - prevStudent) / 2;
                val = (node.value + prevStudent) / 2;
                pos = node;
            }
            prevStudent = node.value;
        }

        if (n - 1 - tail.prev.value > maxDistToClosest)
        {
            pos = tail;
            val = n - 1;
        }

        Node insertedNode = new Node(val);
        Join(pos.prev, insertedNode);
        Join(insertedNode, pos);

        map[val] = insertedNode;

        return val;
    }

    public void Leave(int p)
    {
        Node removedNode = map[p];
        Join(removedNode.prev, removedNode.next);
        map.Remove(p);
    }

    private void Join(Node node1, Node node2)
    {
        node1.next = node2;
        node2.prev = node1;
    }

    private void Remove(Node node)
    {
        Join(node.prev, node.next);
    }
}