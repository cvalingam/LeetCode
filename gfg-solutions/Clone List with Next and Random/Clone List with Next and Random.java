class Node {
    int data;
    Node next;
    Node random;

    Node(int x) {
        data = x;
        next = null;
        random = null;
    }
}

class Solution {
    public Node cloneLinkedList(Node head) {
        if (head == null)
            return null;

        // Step 1: Create new nodes and insert them in the original list
        Node current = head;
        while (current != null) {
            Node newNode = new Node(current.data); // Use current.data instead of current.val
            newNode.next = current.next;
            current.next = newNode;
            current = newNode.next; // Move to the next original node
        }

        // Step 2: Copy the random pointers
        current = head;
        while (current != null) {
            if (current.random != null) {
                current.next.random = current.random.next; // Copy the random pointer
            }
            current = current.next.next; // Move to the next original node
        }

        // Step 3: Separate the new list from the original list
        Node newHead = head.next;
        current = head;
        Node copy = newHead;
        while (current != null) {
            current.next = current.next.next; // Restore the original list
            if (copy.next != null) {
                copy.next = copy.next.next; // Link the copied list
            }
            current = current.next;
            copy = copy.next;
        }

        return newHead;
    }
}