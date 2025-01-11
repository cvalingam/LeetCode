public class Solution
{
    public bool CanConstruct(string s, int k)
    {
        // If |s| < k, we cannot construct k strings from the s.
        if (s.Length < k)
            return false;

        int[] count = new int[26];

        foreach (char c in s)
            count[c - 'a'] ^= 1;

        // If the number of letters that have odd counts > k, the minimum number of
        // palindromic strings we can construct is > k.
        return count.Count(c => c % 2 == 1) <= k;
    }
}