public class Solution
{
    public int MaxIncreasingSubarrays(IList<int> nums)
    {
        int maxLength = 0;
        int previousLength = 0;
        int currentLength = 0;
        int n = nums.Count;

        for (int i = 0; i < n; i++)
        {
            currentLength++;

            if (i == n - 1 || nums[i] >= nums[i + 1])
            {
                maxLength = Math.Max(maxLength,
                                     Math.Max(currentLength / 2,
                                              Math.Min(previousLength, currentLength)));

                previousLength = currentLength;
                currentLength = 0;
            }
        }

        return maxLength;
    }
}