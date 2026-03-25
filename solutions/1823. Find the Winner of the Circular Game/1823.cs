// Approach: Josephus problem recurrence: f(i) = (f(i-1) + k) % i, then return winner + 1.
// Time: O(n) Space: O(1)

public class Solution
{
    public int FindTheWinner(int n, int k)
    {
        int ans = 0;
        for (int i = 2; i <= n; i++)
            ans = (ans + k) % i;

        return ans + 1;
    }
}