public class Solution
{
    public int CountPairs(int[] nums, int k)
    {
        int ans = 0;
        Dictionary<int, List<int>> numToIndices = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Length; ++i)
        {
            if (!numToIndices.ContainsKey(nums[i]))
                numToIndices[nums[i]] = new List<int>();

            numToIndices[nums[i]].Add(i);
        }

        foreach (List<int> indices in numToIndices.Values)
        {
            Dictionary<int, int> gcds = new Dictionary<int, int>();
            foreach (int i in indices)
            {
                int gcd_i = Gcd(i, k);
                foreach (int gcd_j in gcds.Keys)
                {
                    if (gcd_i * gcd_j % k == 0)
                        ans += gcds[gcd_j];
                }
                if (gcds.ContainsKey(gcd_i))
                    gcds[gcd_i]++;
                else
                    gcds[gcd_i] = 1;
            }
        }

        return ans;
    }

    private int Gcd(int a, int b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }
}