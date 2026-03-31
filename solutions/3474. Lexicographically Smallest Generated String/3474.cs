// Approach: First place str2 at every 'T' position in str1 (mandatory placements).
// Fill remaining positions with 'a' (lexicographically smallest).
// For each 'F' position, if the current window accidentally matches str2,
// change the last modifiable character in that window to 'b' to break the match.
// Time: O(n * m) Space: O(n + m)
public class Solution
{
    public string GenerateString(string str1, string str2)
    {
        int n = str1.Length;
        int m = str2.Length;
        int sz = n + m - 1;
        char[] ans = new char[sz];
        bool[] modifiable = new bool[sz];
        for (int i = 0; i < sz; i++)
            modifiable[i] = true;

        // 1. Handle all 'T' positions first.
        for (int i = 0; i < n; ++i)
        {
            if (str1[i] == 'T')
            {
                for (int j = 0; j < m; ++j)
                {
                    int pos = i + j;
                    if (ans[pos] != '\0' && ans[pos] != str2[j])
                        return "";
                    ans[pos] = str2[j];
                    modifiable[pos] = false;
                }
            }
        }

        // 2. Fill all remaining positions with 'a'.
        for (int i = 0; i < sz; ++i)
        {
            if (ans[i] == '\0')
                ans[i] = 'a';
        }

        // 3. Handle all 'F' positions.
        for (int i = 0; i < n; ++i)
        {
            if (str1[i] == 'F' && Match(ans, i, str2))
            {
                int modifiablePos = LastModifiablePosition(i, m, modifiable);
                if (modifiablePos == -1)
                    return "";
                ans[modifiablePos] = 'b';
                modifiable[modifiablePos] = false;
            }
        }

        return new string(ans);
    }

    // Returns true if the substring of ans starting at `i` matches `s`.
    private bool Match(char[] ans, int i, string s)
    {
        for (int j = 0; j < s.Length; ++j)
        {
            if (ans[i + j] != s[j])
                return false;
        }

        return true;
    }

    // Finds the last modifiable position in the substring ans starting at `i`.
    private int LastModifiablePosition(int i, int m, bool[] modifiable)
    {
        int modifiablePos = -1;
        for (int j = 0; j < m; ++j)
        {
            int pos = i + j;
            if (modifiable[pos])
                modifiablePos = pos;
        }
        
        return modifiablePos;
    }
}