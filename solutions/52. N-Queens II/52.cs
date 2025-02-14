public class Solution
{
    public int TotalNQueens(int n)
    {
        int ans = 0;
        Dfs(n, 0, new bool[n], new bool[2 * n - 1], new bool[2 * n - 1], ref ans);
        return ans;
    }

    private void Dfs(int n, int i, bool[] cols, bool[] diag1, bool[] diag2, ref int ans)
    {
        if (i == n)
        {
            ans++;
            return;
        }

        for (int j = 0; j < n; j++)
        {
            if (cols[j] || diag1[i + j] || diag2[j - i + n - 1])
                continue;
            cols[j] = diag1[i + j] = diag2[j - i + n - 1] = true;
            Dfs(n, i + 1, cols, diag1, diag2, ref ans);
            cols[j] = diag1[i + j] = diag2[j - i + n - 1] = false;
        }
    }
}