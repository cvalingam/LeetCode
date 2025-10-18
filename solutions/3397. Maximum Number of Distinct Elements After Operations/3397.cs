public class Solution
{
    public int MaxDistinctElements(int[] nums, int k)
    {
        Array.Sort(nums);

        int n = nums.Length;
        int distinctCount = 0;
        int previousValue = int.MinValue;

        foreach (int currentNum in nums)
        {
            int optimalValue = Math.Min(currentNum + k, Math.Max(currentNum - k, previousValue + 1));

            if (optimalValue > previousValue)
            {
                distinctCount++;
                previousValue = optimalValue;
            }
        }

        return distinctCount;
    }
}