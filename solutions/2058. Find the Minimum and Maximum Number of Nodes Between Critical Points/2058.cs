// Approach: Single pass tracking first and last critical point indices; compute min gap between consecutive.
// Time: O(n) Space: O(1)

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
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        int minDistance = Int32.MaxValue;
        int firstMaIndex = -1, prevMaIndex = -1, index = 1;
        ListNode prev = head;
        ListNode curr = head.next;

        while (curr.next != null)
        {
            if (curr.val > prev.val && curr.val > curr.next.val ||
                curr.val < prev.val && curr.val < curr.next.val)
            {
                if (firstMaIndex == -1)
                    firstMaIndex = index;
                if (prevMaIndex != -1)
                    minDistance = Math.Min(minDistance, index - prevMaIndex);
                prevMaIndex = index;
            }
            prev = curr;
            curr = curr.next;
            index++;
        }

        if (minDistance == Int32.MaxValue)
            return new int[] { -1, -1 };

        return new int[] { minDistance, prevMaIndex - firstMaIndex };
    }
}