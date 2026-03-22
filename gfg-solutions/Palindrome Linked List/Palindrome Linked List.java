class Node {
    int data;
    Node next;

    Node(int d) {
        data = d;
        next = null;
    }
}

class Solution {
    // Function to check whether the list is palindrome.
    boolean isPalindrome(Node head) {
        if (head == null || head.next == null) // edge case
            return true;

        // find middle of linked list
        Node slow = head;
        Node fast = head.next;
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        Node mid = slow;

        // Reverse the half of linked list from mid.next
        Node curr = mid.next;
        mid.next = null;
        Node prev = null;
        Node front = curr.next;

        while (curr != null && curr.next != null) {
            curr.next = prev;
            prev = curr;
            curr = front;
            front = front.next;
        }

        // Check that two halves are equal or not
        slow = head;
        while (slow != null && curr != null) {
            if (slow.data != curr.data)
                return false;
            slow = slow.next;
            curr = curr.next;
        }
        return true;
    }
}

// Version 2
class Solution1 {
    public boolean isPalindrome(Node head) {
        if (head.next == null)
            return true;

        Node fast = head, slow = head, prev = null, nextStart = null;
        while (fast != null) {
            fast = fast.next;
            if (fast == null) { // edge case -> odd no of items, dont consider middle
                nextStart = slow.next;
                slow = prev;
                break;
            }
            if (fast.next == null)
                break;
            fast = fast.next;

            // reverse previous pointers of slow
            Node temp = slow;
            slow = slow.next;
            temp.next = prev;
            prev = temp;
        }

        if (slow != null && nextStart == null) {
            nextStart = slow.next;
            slow.next = prev;
        }

        // simple check for palindrome
        while (nextStart != null && slow != null) {
            if (nextStart.data != slow.data)
                return false;
            nextStart = nextStart.next;
            slow = slow.next;
        }

        return slow == null && nextStart == null;
    }
}