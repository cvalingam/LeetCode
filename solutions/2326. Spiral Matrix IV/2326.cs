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
    public int[][] SpiralMatrix(int m, int n, ListNode head)
    {
        int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        int[][] ans = new int[m][];
        for (int i = 0; i < m; i++)
        {
            ans[i] = new int[n];
            Array.Fill(ans[i], -1);
        }
        int x = 0; // the current x position
        int y = 0; // the current y position
        int d = 0;

        for (ListNode curr = head; curr != null; curr = curr.next)
        {
            ans[x][y] = curr.val;
            int nx = x + dirs[d][0];
            int ny = y + dirs[d][1];
            if (nx < 0 || nx == m || ny < 0 ||
                ny == n || ans[nx][ny] != -1)
                d = (d + 1) % 4;
            x += dirs[d][0];
            y += dirs[d][1];
        }

        return ans;
    }
}