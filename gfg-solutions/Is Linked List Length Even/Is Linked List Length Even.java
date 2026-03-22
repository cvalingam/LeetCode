class Solution {
    public boolean isLengthEven(Node head) {
        Node curr = head;

        int len = 0;
        while (curr != null) {
            curr = curr.next;
            len++;
        }

        return len % 2 == 0;
    }
}