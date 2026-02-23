public class Solution
{
    public bool HasAllCodes(string s, int k)
    {
        int n = 1 << k;
        if (s.Length < n)
            return false;

        bool[] used = new bool[n];

        int window = k == 1 ? 0 : Convert.ToInt32(s.Substring(0, k - 1), 2);
        for (int i = k - 1; i < s.Length; ++i)
        {
            window = (window << 1) + (s[i] - '0');
            window &= n - 1;
            used[window] = true;
        }

        return used.All(u => u);
    }
}