public class Solution
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        int n = nums.Length;
        List<int> ans = new List<int>();
        // sizeEndsAt[i] := the maximum size ends in nums[i]
        int[] sizeEndsAt = new int[n];
        // prevIndex[i] := the best index s.t.
        // 1. nums[i] % nums[prevIndex[i]] == 0 and
        // 2. can increase the size of the subset
        int[] prevIndex = new int[n];
        int maxSize = 0; // Max size of the subset
        int index = -1;  // Track the best ending index

        Array.Fill(sizeEndsAt, 1);
        Array.Fill(prevIndex, -1);
        Array.Sort(nums);

        // Fix the maximum ending number in the subset.
        for (int i = 0; i < n; ++i)
        {
            for (int j = i - 1; j >= 0; --j)
            {
                if (nums[i] % nums[j] == 0 && sizeEndsAt[i] < sizeEndsAt[j] + 1)
                {
                    sizeEndsAt[i] = sizeEndsAt[j] + 1;
                    prevIndex[i] = j;
                }
            }
            // Find a new subset that has a bigger size.
            if (maxSize < sizeEndsAt[i])
            {
                maxSize = sizeEndsAt[i];
                index = i; // Update the best ending index.
            }
        }

        // Loop from the back to the front.
        while (index != -1)
        {
            ans.Add(nums[index]);
            index = prevIndex[index];
        }

        return ans;
    }
}