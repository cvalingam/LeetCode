class Node {
    int data;
    Node next;

    Node(int x) {
        data = x;
        next = null;
    }
}

class Solution {
    public Node sortedInsert(Node head, int data) {
        Node prev = null;
        Node curr = head;

        do {
            prev = curr;
            curr = curr.next;
        } while (curr != head);

        while (curr.data < data) {
            curr = curr.next;
            prev = prev.next;

            if (curr == head)
                break;
        }

        Node newNode = new Node(data);
        prev.next = newNode;
        newNode.next = curr;

        if (head.data > data)
            return newNode;
        else
            return head;
    }
}