public class Solution
{
    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups)
    {
        int n = words.Length;
        List<string> ans = new List<string>();
        // dp[i] := the length of the longest subsequence ending in `words[i]`
        int[] dp = new int[n];
        Array.Fill(dp, 1);
        // prev[i] := the best index of words[i]
        int[] prev = new int[n];
        Array.Fill(prev, -1);

        for (int i = 1; i < n; ++i)
        {
            for (int j = 0; j < i; ++j)
            {
                if (groups[i] == groups[j])
                    continue;
                if (words[i].Length != words[j].Length)
                    continue;
                if (HammingDist(words[i], words[j]) != 1)
                    continue;
                if (dp[i] < dp[j] + 1)
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;
                }
            }
        }

        // Find the last index of the subsequence.
        int index = GetMaxIndex(dp);
        while (index != -1)
        {
            ans.Add(words[index]);
            index = prev[index];
        }

        ans.Reverse();
        return ans;
    }

    private int HammingDist(string s1, string s2)
    {
        int dist = 0;
        for (int i = 0; i < s1.Length; ++i)
        {
            if (s1[i] != s2[i])
                ++dist;
        }

        return dist;
    }

    private int GetMaxIndex(int[] dp)
    {
        int maxIndex = 0;
        for (int i = 0; i < dp.Length; ++i)
        {
            if (dp[i] > dp[maxIndex])
                maxIndex = i;
        }

        return maxIndex;
    }
}