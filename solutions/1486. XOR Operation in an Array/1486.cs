public class Solution
{
    public int XorOperation(int n, int start)
    {
        int ans = 0;
        for (int i = 0; i < n; ++i)
            ans ^= start + 2 * i;
        return ans;
    }
}