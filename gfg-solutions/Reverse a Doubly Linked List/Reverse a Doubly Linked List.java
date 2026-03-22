class Node {
    int data;
    Node next;
    Node prev;

    Node(int data) {
        this.data = data;
        this.next = null;
        this.prev = null;
    }
}

class Solution {
    public Node reverse(Node head) {
        Node current = head;
        Node temp = null;

        while (current != null) {
            // Swap next and prev
            temp = current.prev;
            current.prev = current.next;
            current.next = temp;

            // Move to next node in original list (which is prev after swap)
            current = current.prev;
        }

        // Fix head to point to the new front
        if (temp != null)
            head = temp.prev;

        return head;
    }
}