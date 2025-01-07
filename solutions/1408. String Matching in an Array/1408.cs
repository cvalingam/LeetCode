public class Solution
{
    public IList<string> StringMatching(string[] words)
    {
        List<string> ans = new List<string>();
        foreach (var a in words)
        {
            foreach (var b in words)
            {
                if (a.Length < b.Length && b.IndexOf(a) != -1)
                {
                    ans.Add(a);
                    break;
                }
            }
        }
        return ans;
    }
}