class Node {
    int data;
    Node next;

    Node(int x) {
        data = x;
        next = null;
    }
}

class Solution {
    public static Node findFirstNode(Node head) {
        Node slow = head;
        Node fast = head;

        // Step 1: Detect the loop using Floyd's Cycle Detection
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;

            // If slow and fast meet, a loop is detected
            if (slow == fast)
                break;
        }

        // If no loop is detected, return null
        if (fast == null || fast.next == null)
            return null;

        // Step 2: Find the starting node of the loop
        slow = head;
        while (slow != fast) {
            slow = slow.next;
            fast = fast.next;
        }

        // The node where slow and fast meet is the start of the loop
        return slow;
    }
}