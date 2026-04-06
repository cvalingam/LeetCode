// Approach: Traverse the sorted DLL to find the correct position, then update pointers.
// Time: O(n) Space: O(1)
class Solution {
    public Node sortedInsert(Node head, int x) {
        Node newNode = new Node(x);
        if (head == null || head.data >= x) {
            newNode.next = head;
            return newNode;
        }

        Node temp = head;
        while (temp.next != null && temp.next.data < x)
            temp = temp.next;

        newNode.next = temp.next;
        temp.next = newNode;
        return head;
    }
}