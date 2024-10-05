public class Solution
{
    public IList<string> LetterCasePermutation(string s)
    {
        List<string> ans = new List<string>();
        Dfs(new StringBuilder(s), 0, ans);
        return ans;
    }

    private void Dfs(StringBuilder sb, int i, List<string> ans)
    {
        if (i == sb.Length)
        {
            ans.Add(sb.ToString());
            return;
        }
        if (char.IsDigit(sb[i]))
        {
            Dfs(sb, i + 1, ans);
            return;
        }

        sb[i] = char.ToLower(sb[i]);
        Dfs(sb, i + 1, ans);
        sb[i] = char.ToUpper(sb[i]);
        Dfs(sb, i + 1, ans);
    }
}