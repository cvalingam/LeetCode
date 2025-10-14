public class Solution
{
    public bool HasIncreasingSubarrays(IList<int> nums, int k)
    {
        int maxValidLength = 0;
        int previousLength = 0;
        int currentLength = 0;

        int n = nums.Count;

        for (int i = 0; i < n; i++)
        {
            currentLength++;

            if (i == n - 1 || nums[i] >= nums[i + 1])
            {
                maxValidLength = Math.Max(maxValidLength,
                                         Math.Max(currentLength / 2,
                                                  Math.Min(previousLength, currentLength)));

                previousLength = currentLength;
                currentLength = 0;
            }
        }

        return maxValidLength >= k;
    }
}