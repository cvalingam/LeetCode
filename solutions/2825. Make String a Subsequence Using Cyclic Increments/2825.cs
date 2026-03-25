// Approach: Two-pointer; advance str2 pointer when str1[i] matches str2[j] exactly or cyclically.
// Time: O(|str1|) Space: O(1)

public class Solution
{
    public bool CanMakeSubsequence(string str1, string str2)
    {
        int i = 0; // str2's index

        foreach (char c in str1)
        {
            if (c == str2[i] || ((char)('a' + ((c - 'a' + 1) % 26)) == str2[i]))
            {
                if (++i == str2.Length)
                    return true;
            }
        }

        return false;
    }
}