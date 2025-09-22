public class Solution
{
    public int MaxFrequencyElements(int[] nums)
    {
        int n = nums.Length;
        var map = new Dictionary<int, int>();

        int maxFreq = 1;
        for (int i = 0; i < n; i++)
        {
            int val = nums[i];
            if (map.ContainsKey(val))
            {
                int freq = map[val] + 1;
                map[val] = freq;
                maxFreq = Math.Max(freq, maxFreq);
            }
            else
                map.Add(val, 1);
        }

        int cnt = 0;
        foreach (KeyValuePair<int, int> kvp in map)
        {
            if (kvp.Value == maxFreq)
                cnt += kvp.Value;
        }

        return cnt;
    }
}