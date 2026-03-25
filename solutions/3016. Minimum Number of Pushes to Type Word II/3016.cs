// Approach: Frequency sort; assign highest-freq chars to fewest-press keys (8 chars per press tier).
// Time: O(n + 26 log 26) Space: O(26)

public class Solution
{
    public int MinimumPushes(string word)
    {
        int ans = 0;
        int[] count = new int[26];

        foreach (char ch in word)
            ++count[ch - 'a'];

        Array.Sort(count);

        for (int i = 0; i < 26; i++)
            ans += count[26 - i - 1] * (i / 8 + 1);

        return ans;
    }
}