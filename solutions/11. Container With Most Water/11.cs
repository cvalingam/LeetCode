public class Solution
{
    public int MaxArea(int[] height)
    {
        int n = height.Length;
        int l = 0;
        int r = n - 1;
        int maxWater = 0;
        while (l <= r)
        {
            if (height[l] <= height[r])
            {
                int water = height[l] * (r - l);
                maxWater = Math.Max(water, maxWater);
                l++;
            }
            else
            {
                int water = height[r] * (r - l);
                maxWater = Math.Max(water, maxWater);
                r--;
            }
        }

        return maxWater;
    }
}