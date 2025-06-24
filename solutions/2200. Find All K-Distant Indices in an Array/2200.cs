public class Solution
{
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
        // The length of the array 'nums'
        int n = nums.Length;
        // Initialize the list to store the answer
        List<int> kDistantIndices = new List<int>();
        // Iterate over all elements of 'nums'
        for (int i = 0; i < n; ++i)
        {
            // Check elements again to find indices within distance 'k' of 'key' in 'nums'
            for (int j = 0; j < n; ++j)
            {
                // If the absolute difference between indices 'i' and 'j' is less than or equal to 'k'
                // and the current element nums[j] is equal to 'key', the condition is met
                if (Math.Abs(i - j) <= k && nums[j] == key)
                {
                    // Add the current index 'i' to the list of results
                    kDistantIndices.Add(i);
                    // Break from the inner loop since we've found the key at this 'i' index
                    break;
                }
            }
        }
        // Return the list of indices that are within distance 'k' from the elements equal to 'key'
        return kDistantIndices;
    }
}