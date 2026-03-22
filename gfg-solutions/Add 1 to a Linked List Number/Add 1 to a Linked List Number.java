class Node {
    int data;
    Node next;

    Node(int x) {
        data = x;
        next = null;
    }
}

class Solution {
    public Node addOne(Node head) {
        Node num = reverse(head);
        Node rev = num;

        int sum = num.data + 1;
        int carry = sum / 10;
        num.data = sum % 10;

        while (carry > 0) {
            if (num.next == null)
                num.next = new Node(0);

            num = num.next;
            sum = num.data + carry;
            num.data = sum % 10;
            carry = sum / 10;
        }

        return reverse(rev);
    }

    Node reverse(Node head) {
        if (head == null || head.next == null)
            return head;

        Node prev = null;
        Node curr = head;
        Node next = null;

        while (curr != null) {
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }
}