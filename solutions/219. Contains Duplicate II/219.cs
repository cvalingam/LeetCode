// Approach: HashMap stores the most recent index at which each value was seen.
// For each element nums[i]: if nums[i] already exists in the map and i - map[nums[i]] <= k, return true.
// Otherwise update the map with the current index.
// This single-pass approach uses the last seen index, which gives the smallest possible gap.
// Time: O(n) Space: O(n) for the map.

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