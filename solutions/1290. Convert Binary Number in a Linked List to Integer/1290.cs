/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public int GetDecimalValue(ListNode head)
    {
        int number = 0; // Initialize a variable to store the decimal number.

        // Iterate through each node of the list until the end is reached.
        while (head != null)
        {
            // Left-shift 'number' by 1 bit to make space for the new bit, and then
            // combine it with the current node's value using bitwise OR operation.
            number = (number << 1) | head.val;

            // Move to the next node in the list.
            head = head.next;
        }

        // Return the decimal number that is represented by the binary list.
        return number;
    }
}