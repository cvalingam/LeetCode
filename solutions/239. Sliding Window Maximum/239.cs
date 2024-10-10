public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        int n = nums.Length;
        int j = 0;
        int[] result = new int[n - k + 1];
        List<int> sw = new List<int>(k);

        for (int i = 0; i < n; i++)
        {
            while (sw.Count > 0 && sw[0] == i - k)
                sw.RemoveAt(0);

            while (sw.Count > 0 && nums[sw[sw.Count - 1]] < nums[i])
                sw.RemoveAt(sw.Count - 1);

            sw.Insert(sw.Count, i);

            if (i >= k - 1)
                result[j++] = nums[sw[0]];
        }

        return result;
    }
}