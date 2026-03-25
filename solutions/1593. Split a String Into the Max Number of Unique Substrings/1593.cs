// Approach: DFS backtracking trying all prefix splits while maintaining a seen set of used substrings.
// Time: O(n * 2^n) Space: O(n)

public class Solution
{
    private int ans = 0;
    public int MaxUniqueSplit(string s)
    {
        Dfs(s, 0, new HashSet<string>());
        return ans;
    }

    private void Dfs(string s, int start, HashSet<string> seen)
    {
        if (start == s.Length)
        {
            ans = Math.Max(ans, seen.Count);
            return;
        }

        for (int i = start + 1; i <= s.Length; ++i)
        {
            string cand = s.Substring(start, i - start);
            if (seen.Contains(cand))
                continue;
            seen.Add(cand);
            Dfs(s, i, seen);
            seen.Remove(cand);
        }
    }
}