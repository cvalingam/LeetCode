// Approach: We are not given the head, so standard deletion by relinking from the previous node is impossible.
// Instead, copy the next node's value into the current node and skip the next node.
// node.val = node.next.val; node.next = node.next.next;
// This effectively 'moves' the next node into the current position, achieving the same observable effect.
// Guaranteed by the problem: the node to delete is never the tail node.
// Time: O(1) Space: O(1).

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution
{
    public void DeleteNode(ListNode node)
    {
        if (node.next != null)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}