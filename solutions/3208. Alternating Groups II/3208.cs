public class Solution
{
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
        int n = colors.Length;
        int ans = 0, cnt = 0;
        for (int i = 0; i < n << 1; ++i)
        {
            if (i > 0 && colors[i % n] == colors[(i - 1) % n])
                cnt = 1;
            else
                ++cnt;
                
            ans += i >= n && cnt >= k ? 1 : 0;
        }
        return ans;
    }
}