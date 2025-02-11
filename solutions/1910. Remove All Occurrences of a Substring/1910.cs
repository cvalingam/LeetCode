public class Solution
{
    public string RemoveOccurrences(string s, string part)
    {
        int n = s.Length;
        int k = part.Length;

        StringBuilder sb = new StringBuilder(s);
        int j = 0; // sb's index

        for (int i = 0; i < n; ++i)
        {
            sb[j++] = s[i];
            if (j >= k && sb.ToString().Substring(j - k, k) == part)
                j -= k;
        }

        return sb.ToString().Substring(0, j);
    }
}