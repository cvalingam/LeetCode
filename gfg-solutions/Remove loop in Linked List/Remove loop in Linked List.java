class Node {
    int data;
    Node next;
}

class Solution {
    // Function to remove a loop in the linked list.
    public static void removeLoop(Node head) {
        if (head == null || head.next == null)
            return; // If list is empty or contains only one node, no loop can exist.

        Node slow = head, fast = head;

        // Detect loop using Floyd's Cycle Detection Algorithm
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;

            // If slow and fast meet, a loop is detected
            if (slow == fast) {
                removeLoopNode(head, slow);
                return;
            }
        }
    }

    // Helper function to remove the loop
    private static void removeLoopNode(Node head, Node loopNode) {
        Node ptr1 = head;
        Node ptr2 = loopNode;

        // Find the node where the loop starts
        while (ptr1 != ptr2) {
            ptr1 = ptr1.next;
            ptr2 = ptr2.next;
        }

        // Now `ptr1` (or `ptr2`) is at the loop start node.
        // Find the last node in the loop
        Node last = ptr1;
        while (last.next != ptr1)
            last = last.next;

        // Break the loop by setting the next of the last node to null
        last.next = null;
    }
}