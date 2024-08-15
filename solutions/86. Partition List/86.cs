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
    public ListNode Partition(ListNode head, int x)
    {
        ListNode beforeHead = new ListNode();
        ListNode afterHead = new ListNode();
        ListNode before = beforeHead;
        ListNode after = afterHead;

        while (head != null)
        {
            if (head.val < x)
            {
                before.next = head;
                before = head;
            }
            else
            {
                after.next = head;
                after = head;
            }
            head = head.next;
        }

        after.next = null;
        before.next = afterHead.next;

        return beforeHead.next;
    }
}