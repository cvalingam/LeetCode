public class Solution
{
    public int MinimumIndex(IList<int> nums)
    {
        int n = nums.Count;
        Dictionary<int, int> count1 = new Dictionary<int, int>();
        Dictionary<int, int> count2 = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            if (count2.ContainsKey(num))
                count2[num]++;
            else
                count2[num] = 1;
        }

        for (int i = 0; i < n; ++i)
        {
            if (count1.ContainsKey(nums[i]))
                count1[nums[i]]++;
            else
                count1[nums[i]] = 1;

            if (count2.ContainsKey(nums[i]))
            {
                count2[nums[i]]--;
                if (count2[nums[i]] == 0)
                    count2.Remove(nums[i]);
            }

            int freq1 = count1[nums[i]];
            int freq2 = count2.ContainsKey(nums[i]) ? count2[nums[i]] : 0;

            if (freq1 * 2 > i + 1 && freq2 * 2 > n - 1 - i)
                return i;
        }

        return -1;
    }
}