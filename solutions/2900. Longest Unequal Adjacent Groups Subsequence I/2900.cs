// Approach: Greedy; always pick element if its group differs from the last selected group.
// Time: O(n) Space: O(n)

public class Solution
{
    public IList<string> GetLongestSubsequence(string[] words, int[] groups)
    {
        var ans = new List<string>();
        int groupId = -1;
        for (int i = 0; i < groups.Length; i++)
        {
            if (groups[i] != groupId)
            {
                groupId = groups[i];
                ans.Add(words[i]);
            }
        }

        return ans;
    }
}