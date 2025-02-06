public class Solution
{
    public int TupleSameProduct(int[] nums)
    {
        int ans = 0;
        Dictionary<int, int> count = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; ++i)
        {
            for (int j = 0; j < i; ++j)
            {
                int prod = nums[i] * nums[j];
                ans += count.GetValueOrDefault(prod, 0) * 8;
                if (count.ContainsKey(prod))
                    count[prod]++;
                else
                    count[prod] = 1;
            }
        }

        return ans;
    }
}