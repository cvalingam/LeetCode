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
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (head == null || left == right)
            return head;

        ListNode dummy = new ListNode(0, head);
        ListNode prev = dummy;

        for (int i = 0; i < left - 1; ++i)
            prev = prev.next; // Point to the node before the sublist [m, n].

        ListNode tail = prev.next; // Be the tail of the sublist [m, n].

        // Reverse the sublist [m, n] one by one.
        for (int i = 0; i < right - left; ++i)
        {
            ListNode cache = tail.next;
            tail.next = cache.next;
            cache.next = prev.next;
            prev.next = cache;
        }

        return dummy.next;
    }
}