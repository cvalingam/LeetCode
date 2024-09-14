public class Solution
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            if (map.ContainsKey(nums[i]))
            {
                int prevIndex = map[nums[i]];
                int value = Math.Abs(prevIndex - i);
                if (value <= k)
                    return true;
                map[nums[i]] = i;
            }
            else
            {
                map.Add(nums[i], i);
            }
        }

        return false;
    }
}