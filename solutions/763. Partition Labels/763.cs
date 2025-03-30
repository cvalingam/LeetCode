public class Solution
{
    public IList<int> PartitionLabels(string s)
    {
        List<int> ans = new List<int>();
        int[] rightmost = new int[26];

        for (int i = 0; i < s.Length; ++i)
            rightmost[s[i] - 'a'] = i;

        int l = 0; // the leftmost index of the current running string
        int r = 0; // the rightmost index of the current running string

        for (int i = 0; i < s.Length; ++i)
        {
            r = Math.Max(r, rightmost[s[i] - 'a']);
            if (r == i)
            {
                ans.Add(i - l + 1);
                l = i + 1;
            }
        }

        return ans;
    }
}