public class Solution
{
    public int[] ConstructDistancedSequence(int n)
    {
        var ans = new int[2 * n - 1];
        Dfs(n, 0, 0, ans);
        return ans;
    }

    private bool Dfs(int n, int i, int mask, int[] ans)
    {
        if (i == ans.Length)
            return true;
        if (ans[i] > 0)
            return Dfs(n, i + 1, mask, ans);

        // Greedily fill in `ans` in descending order.
        for (int num = n; num >= 1; --num)
        {
            if ((mask >> num & 1) != 0)
                continue;
            if (num == 1)
            {
                ans[i] = num;
                if (Dfs(n, i + 1, mask | (1 << num), ans))
                    return true;
                ans[i] = 0;
            }
            else
            {  // num in [2, n]
                if (i + num >= ans.Length || ans[i + num] > 0)
                    continue;
                ans[i] = num;
                ans[i + num] = num;
                if (Dfs(n, i + 1, mask | (1 << num), ans))
                    return true;
                ans[i + num] = 0;
                ans[i] = 0;
            }
        }

        return false;
    }
}