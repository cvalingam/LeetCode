// Approach: Characters at even indices can be freely rearranged among even positions (and odd among
// odd) via repeated swaps of any two same-parity indices. So s1 can be transformed to s2 iff the
// multiset of even-index chars and the multiset of odd-index chars both match between s1 and s2.
// Track net character frequency counts for even and odd positions separately.
// Time: O(n) Space: O(1)
public class Solution
{
    public bool CheckStrings(string s1, string s2)
    {
        int[][] count = new int[2][];
        count[0] = new int[26];
        count[1] = new int[26];

        for (int i = 0; i < s1.Length; ++i)
        {
            count[i % 2][s1[i] - 'a']++;
            count[i % 2][s2[i] - 'a']--;
        }

        for (int i = 0; i < 26; ++i)
        {
            if (count[0][i] != 0 || count[1][i] != 0)
                return false;
        }

        return true;
    }
}