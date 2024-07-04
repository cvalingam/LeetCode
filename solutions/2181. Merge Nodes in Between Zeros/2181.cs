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
    public ListNode MergeNodes(ListNode head)
    {
        ListNode curr = head.next;

        while (curr != null)
        {
            ListNode running = curr;
            int sum = 0;
            while (running.val > 0)
            {
                sum += running.val;
                running = running.next;
            }

            curr.val = sum;
            curr.next = running.next;
            curr = curr.next;
        }

        return head.next;
    }
}