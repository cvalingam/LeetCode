class Node {
    int data;
    Node next;

    Node(int d) {
        data = d;
        next = null;
    }
}

class Intersect {
    // Function to find intersection point in Y shaped Linked Lists.
    int intersectPoint(Node head1, Node head2) {
        Node temp = head1;
        while (temp != null) {
            temp.data += 21000;
            temp = temp.next;
        }

        temp = head2;
        while (temp != null) {
            if (temp.data > 10000)
                return (temp.data - 21000);

            temp = temp.next;
        }

        return -1;
    }
}