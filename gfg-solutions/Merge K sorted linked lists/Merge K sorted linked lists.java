import java.util.*;

class Node {
    int data;
    Node next;

    Node(int key) {
        data = key;
        next = null;
    }
}

class Solution {
    // Function to merge K sorted linked list.
    Node mergeKLists(List<Node> arr) {
        PriorityQueue<Node> pq = new PriorityQueue<>((n1, n2) -> n1.data - n2.data);
        for (Node node : arr)
            pq.add(node);

        Node head = new Node(-1);
        Node tail = head;

        while (!pq.isEmpty()) {
            Node node = pq.poll();
            tail.next = new Node(node.data);
            node = node.next;
            if (node != null)
                pq.add(node);

            tail = tail.next;
        }

        head = head.next;
        return head;
    }
}