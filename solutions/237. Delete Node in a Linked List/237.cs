// Approach: Copy the next node’s value into the current node and skip
// the next node (no access to the head is needed).
// Time: O(1) Space: O(1)

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