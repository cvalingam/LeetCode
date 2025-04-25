public class Solution
{
    public long CountInterestingSubarrays(IList<int> nums, int modulo, int k)
    {
        long ans = 0;
        int prefix = 0; // (number of nums[i] % modulo == k so far) % modulo
        Dictionary<int, int> prefixCount = new Dictionary<int, int>();
        prefixCount[0] = 1;

        foreach (var num in nums)
        {
            if (num % modulo == k)
                prefix = (prefix + 1) % modulo;
            ans += prefixCount.GetValueOrDefault((prefix - k + modulo) % modulo, 0);
            if (prefixCount.ContainsKey(prefix))
                prefixCount[prefix]++;
            else
                prefixCount[prefix] = 1;
        }

        return ans;
    }
}