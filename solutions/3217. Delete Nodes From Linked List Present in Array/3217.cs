
// Approach: HashSet of values to remove; traverse list skipping nodes whose value is in the set.
// Time: O(n + m) Space: O(m)

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
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        ListNode dummy = new ListNode(0, head);
        HashSet<int> numsSet = new HashSet<int>(nums);

        for (ListNode curr = dummy; curr.next != null;)
        {
            if (numsSet.Contains(curr.next.val))
                curr.next = curr.next.next;
            else
                curr = curr.next;
        }

        return dummy.next;
    }
}