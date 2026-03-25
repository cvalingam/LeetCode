// Approach: Backtracking tracking open and close parenthesis counts.
// Add '(' if open < n, add ')' if close < open.
// Time: O(4^n/√n) Space: O(n)

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        IList<string> dp = new List<string>();
        Generate(0, n, 0, 0, "", dp);
        return dp;
    }

    private void Generate(int ind, int n, int op, int cl, string res, IList<string> ans)
    {
        if (op < cl || op > n || cl > n)
            return;

        if (ind == 2 * n)
        {
            ans.Add(res);
            return;
        }

        Generate(ind + 1, n, op + 1, cl, res + '(', ans);
        Generate(ind + 1, n, op, cl + 1, res + ')', ans);
    }
}