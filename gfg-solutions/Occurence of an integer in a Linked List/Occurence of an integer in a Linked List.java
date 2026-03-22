class Node {
    int data;
    Node next;

    Node(int key) {
        data = key;
        next = null;
    }
}

class Solution {
    public static int count(Node head, int key) {
        int count = 0;
        Node temp = head;
        while (temp != null) {
            if (temp.data == key) {
                count++;
            }
            temp = temp.next;
        }
        return count;
    }
}