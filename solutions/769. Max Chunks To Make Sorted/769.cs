// Approach: Single pass tracking running maximum; whenever running max equals current index, a valid chunk boundary is found.
// Time: O(n) Space: O(1)

public class Solution
{
    public int MaxChunksToSorted(int[] arr)
    {
        int noOfChunks = 0;
        int max = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            max = Math.Max(max, arr[i]);
            if (max == i)
                noOfChunks++;
        }

        return noOfChunks;
    }
}