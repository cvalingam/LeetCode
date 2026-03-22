class Solution {
    // Function to append a new node with newData at the end of a linked list
    Node[] alternatingSplitList(Node head) {
        Node first = new Node(0), second = new Node(0);
        Node dummyFirst = first, dummySecond = second;
        int i = 1;
        while (head != null) {
            if (i % 2 == 0) {
                dummySecond.next = head;
                dummySecond = dummySecond.next;
            } else {
                dummyFirst.next = head;
                dummyFirst = dummyFirst.next;
            }
            head = head.next;
            i++;
        }
        dummyFirst.next = null;
        dummySecond.next = null;
        return new Node[] { first.next, second.next };
    }
}