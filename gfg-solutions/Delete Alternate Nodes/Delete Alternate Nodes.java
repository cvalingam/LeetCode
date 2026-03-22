class Solution {
    public void deleteAlt(Node head) {
        Node prev = null;
        Node temp = head;
        int cnt = 0;
        while (temp != null) {
            cnt++;
            if (cnt % 2 == 0) {
                prev.next = temp.next;
            }
            prev = temp;
            temp = temp.next;
        }
    }
}

class Node {
    int data;
    Node next;

    public Node(int data) {
        this.data = data;
    }
}