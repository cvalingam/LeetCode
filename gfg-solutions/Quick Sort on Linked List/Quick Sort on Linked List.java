class Node {
    int data;
    Node next;

    Node(int key) {
        data = key;
        next = null;
    }

}

class GfG {
    public static Node quickSort(Node head) {
        if (head == null || head.next == null)
            return head;

        Node[] smaller = new Node[1];
        Node[] greater = new Node[1];

        partition(head, smaller, greater);

        smaller[0] = quickSort(smaller[0]);
        greater[0] = quickSort(greater[0]);

        head.next = greater[0];
        Node temp = smaller[0];
        while (temp != null && temp.next != null)
            temp = temp.next;

        if (temp != null)
            temp.next = head;
        else
            smaller[0] = head;

        return smaller[0];
    }

    private static void partition(Node pivot, Node[] smaller, Node[] greater) {
        Node temp = pivot.next;
        while (temp != null) {
            Node next = temp.next;
            if (temp.data <= pivot.data) {
                temp.next = smaller[0];
                smaller[0] = temp;
            } else {
                temp.next = greater[0];
                greater[0] = temp;
            }
            temp = next;
        }
    }
}