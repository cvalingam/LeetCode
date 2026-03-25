// Approach: For each k, check if (n - k(k-1)/2) is positive and divisible by k; count valid partitions.
// Time: O(√n) Space: O(1)

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