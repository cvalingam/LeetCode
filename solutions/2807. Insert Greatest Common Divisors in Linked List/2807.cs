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
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        for (ListNode curr = head; curr.next != null;)
        {
            ListNode inserted = new ListNode(Gcd(curr.val, curr.next.val), curr.next);
            curr.next = inserted;
            curr = inserted.next;
        }
        return head;
    }

    private int Gcd(int a, int b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }
}