public class Solution
{
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
    {
        if (nums.Length == 0 || indexDiff <= 0 || valueDiff < 0)
            return false;

        long mn = nums.Min();
        long diff = valueDiff + 1; // In case that `valueDiff` equals 0.
        // Use long because of corner case int.MaxValue - (-1) will overflow
        Dictionary<long, long> bucket = new Dictionary<long, long>();

        for (int i = 0; i < nums.Length; ++i)
        {
            long num = (long)nums[i];
            long key = GetKey(nums[i], mn, diff);
            if (bucket.ContainsKey(key)) // the current bucket
                return true;
            if (bucket.ContainsKey(key - 1) && num - bucket[key - 1] < diff) // the left adjacent bucket
                return true;
            if (bucket.ContainsKey(key + 1) && bucket[key + 1] - num < diff) // the right adjacent bucket
                return true;
            bucket[key] = num;
            if (i >= indexDiff)
                bucket.Remove(GetKey(nums[i - indexDiff], mn, diff));
        }

        return false;
    }

    private long GetKey(int num, long mn, long diff)
    {
        return (num - mn) / diff;
    }
}