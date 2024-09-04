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
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        if (head == null || k == 1) return head;
        ListNode dummy = new ListNode();
        dummy.next = head;

        ListNode prev = dummy, curr = dummy, nex = dummy;
        int cnt = 0;

        while (curr.next != null)
        {
            curr = curr.next;
            cnt++;
        }

        while (cnt >= k)
        {
            curr = prev.next;
            nex = curr.next;

            for (int i = 1; i < k; i++)
            {
                curr.next = nex.next;
                nex.next = prev.next;
                prev.next = nex;
                nex = curr.next;
            }
            prev = curr;
            cnt -= k;
        }

        return dummy.next;
    }
}