class Solution {
    // Function to reverse a circular linked list
    Node reverse(Node head) {
        if (head == null)
            return head;

        Node prev = null;
        Node cur = head;
        Node nex = head;

        do {
            nex = cur.next;
            cur.next = prev;
            prev = cur;
            cur = nex;
        } while (cur != head);

        head.next = prev;
        return head = prev;
    }

    // Function to delete a node from the circular linked list
    Node deleteNode(Node head, int key) {
        if (head == null)
            return head;
            
        Node prev = null;
        Node cur = head;

        do {
            if (cur.data == key) {
                if (prev == null) {
                    Node temp = head;
                    do {
                        temp = temp.next;
                    } while (temp.next != head);
                    temp.next = head.next;
                    return head = head.next;
                } else {
                    prev.next = cur.next;
                    return head;
                }
            }
            prev = cur;
            cur = cur.next;
        } while (cur != head);
        return head;
    }
}