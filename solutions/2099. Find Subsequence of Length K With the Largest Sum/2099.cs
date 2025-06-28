public class Solution
{
    public int[] MaxSubsequence(int[] nums, int k)
    {
        // Initialize an array 'ans' to store the result subsequence of length k
        int[] ans = new int[k];

        // Create a list 'indices' to keep track of the original indices of the array elements
        List<int> indices = new List<int>();

        // Loop to fill 'indices' with the array indices
        for (int i = 0; i < nums.Length; ++i)
            indices.Add(i);

        // Sort 'indices' based on the values in 'nums' from highest to lowest
        indices.Sort((i1, i2) => nums[i2].CompareTo(nums[i1]));

        // Initialize a temporary array 'topIndices' to store the first k sorted indices
        int[] topIndices = new int[k];
        for (int i = 0; i < k; ++i)
            topIndices[i] = indices[i];

        // Sort 'topIndices' to maintain the original order of selected k elements
        Array.Sort(topIndices);

        // Fill the 'ans' array with the elements corresponding to the sorted indices
        for (int i = 0; i < k; ++i)
            ans[i] = nums[topIndices[i]];

        // Return the result array containing the max subsequence of length k
        return ans;
    }
}