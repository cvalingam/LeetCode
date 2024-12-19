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