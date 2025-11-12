public class Solution
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;
        int ones = nums.Where(x => x == 1).Count();

        if (ones > 0)
            return n - ones;

        int minOps = Int32.MaxValue;

        for (int i = 0; i < n; i++)
        {
            int g = nums[i];
            for (int j = i + 1; j < n; j++)
            {
                g = gcd(g, nums[j]);
                if (g == 1)
                {
                    minOps = Math.Min(minOps, j - i);
                    break;
                }
            }
        }

        return minOps == Int32.MaxValue ? -1 : minOps + n - 1;
    }

    int gcd(int a, int b)
    {
        return b == 0 ? a : gcd(b, a % b);
    }
}