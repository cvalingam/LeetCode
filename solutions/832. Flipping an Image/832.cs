// Approach: For each row, XOR both ends with 1 while swapping them inward; handles middle element in-place.
// Time: O(n²) Space: O(1)

public class Solution
{
    public int[][] FlipAndInvertImage(int[][] image)
    {
        int n = image[0].Length;

        foreach (int[] row in image)
        {
            for (int i = 0; i < (n + 1) / 2; i++)
            {
                int temp = row[i] ^ 1;
                row[i] = row[n - 1 - i] ^ 1;
                row[n - 1 - i] = temp;
            }
        }

        return image;
    }
}