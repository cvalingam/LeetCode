class Solution {
    // Function to count nodes of a linked list.
    public int getCount(Node head) {
        Node curr = head;
        int cnt = 0;

        while (curr != null) {
            cnt += 1;
            curr = curr.next;
        }

        return cnt;
    }
}

class Node {
    int data;
    Node next;

    Node(int a) {
        data = a;
        next = null;
    }
}