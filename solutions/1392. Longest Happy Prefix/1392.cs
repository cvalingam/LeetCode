public class Solution
{
    public string LongestPrefix(string s)
    {
        const int kBase = 26;
        const long kHash = 8417508174513L;
        int n = s.Length;
        int maxLength = 0;
        long pow = 1;
        long prefixHash = 0; // the hash of s[0..i]
        long suffixHash = 0; // the hash of s[j..n)

        for (int i = 0, j = n - 1; i < n - 1; ++i, --j)
        {
            prefixHash = (prefixHash * kBase + Val(s[i])) % kHash;
            suffixHash = (Val(s[j]) * pow + suffixHash) % kHash;
            pow = pow * kBase % kHash;
            if (prefixHash == suffixHash)
                maxLength = i + 1;
        }

        return s.Substring(0, maxLength);
    }

    private int Val(char c)
    {
        return c - 'a';
    }
}