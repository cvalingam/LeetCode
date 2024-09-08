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
    public ListNode[] SplitListToParts(ListNode root, int k)
    {
        ListNode[] ans = new ListNode[k];
        int length = GetLength(root);
        int subLength = length / k;
        int remainder = length % k;

        ListNode prev = null;
        ListNode head = root;

        for (int i = 0; i < k; ++i, --remainder)
        {
            ans[i] = head;
            for (int j = 0; j < subLength + (remainder > 0 ? 1 : 0); ++j)
            {
                prev = head;
                head = head.next;
            }
            if (prev != null)
                prev.next = null;
        }

        return ans;
    }

    private int GetLength(ListNode root)
    {
        int length = 0;
        for (ListNode curr = root; curr != null; curr = curr.next)
            ++length;
        return length;
    }
}