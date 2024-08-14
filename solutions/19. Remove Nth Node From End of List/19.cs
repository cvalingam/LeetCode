public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode start = new ListNode();
        start.next = head;
        ListNode slow = start;
        ListNode fast = start;
        for (int i = 1; i <= n; i++)
        {
            fast = fast.next;
        }

        while (fast.next != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        slow.next = slow.next.next;
        return start.next;
    }
}