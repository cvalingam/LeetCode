public class Solution
{
    public int MinCapability(int[] nums, int k)
    {
        int l = nums.Min();
        int r = nums.Max();

        while (l < r)
        {
            int m = (l + r) / 2;
            if (NumStolenHouses(nums, m) >= k)
                r = m;
            else
                l = m + 1;
        }

        return l;
    }

    private int NumStolenHouses(int[] nums, int capacity)
    {
        int stolenHouses = 0;
        for (int i = 0; i < nums.Length; ++i)
        {
            if (nums[i] <= capacity)
            {
                ++stolenHouses;
                ++i;
            }
        }
        return stolenHouses;
    }
}