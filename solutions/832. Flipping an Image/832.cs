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