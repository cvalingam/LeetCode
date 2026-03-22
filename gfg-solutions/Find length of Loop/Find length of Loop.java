class Node {
    int data;
    Node next;

    Node(int d) {
        data = d;
        next = null;
    }
}

class Solution {
    // Function to find the length of a loop in the linked list.
    public int countNodesinLoop(Node head) {
        boolean loop = false;

        Node slow = head;
        Node fast = head;

        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) {
                loop = true;
                break;
            }
        }

        if (!loop)
            return 0;

        int count = 1;
        fast = fast.next;

        while (fast != slow) {
            count++;
            fast = fast.next;
        }

        return count;
    }
}

class Solution1 {
    // Function to find the length of a loop in the linked list.
    public int countNodesinLoop(Node head) {
        Node slow = head;
        Node fast = head;

        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) {
                int count = 1;
                Node temp = slow.next;
                while (temp != slow) {
                    count++;
                    temp = temp.next;
                }
                return count;
            }
        }

        return 0;
    }
}