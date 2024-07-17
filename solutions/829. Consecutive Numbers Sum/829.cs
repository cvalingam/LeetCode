public class Solution
{
    public int ConsecutiveNumbersSum(int n)
    {
        int ans = 0;
        for (int i = 1, triangleNum = i; triangleNum <= n; ++i, triangleNum += i)
            if ((n - triangleNum) % i == 0)
                ++ans;
        return ans;
    }
}