class Node {
    int data;
    Node next;

    Node(int d) {
        data = d;
        next = null;
    }
}

class Solution {
    Node sortedMerge(Node head1, Node head2) {
        Node temp1 = head1;
        Node temp2 = head2;

        Node ans = new Node(0);
        Node head = ans;
        while (temp1 != null && temp2 != null) {
            if (temp1.data < temp2.data) {
                head.next = temp1;
                head = head.next;
                temp1 = temp1.next;
            } else {
                head.next = temp2;
                head = head.next;
                temp2 = temp2.next;
            }
        }

        if (temp1 != null)
            head.next = temp1;

        if (temp2 != null)
            head.next = temp2;

        return ans.next;
    }
}