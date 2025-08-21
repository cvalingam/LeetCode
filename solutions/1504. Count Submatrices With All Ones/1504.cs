public class Solution
{
    public int NumSubmat(int[][] mat)
    {
        int rows = mat.Length; // the number of rows in given matrix
        int cols = mat[0].Length; // the number of columns in given matrix
        int[][] width = new int[rows][]; // buffer to store the width of consecutive ones ending at (i, j)

        // Initialize the width array
        for (int i = 0; i < rows; i++)
            width[i] = new int[cols];

        // Compute the width matrix
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                // If the cell contains a '1', calculate the width
                if (mat[i][j] == 1)
                    width[i][j] = (j == 0) ? 1 : 1 + width[i][j - 1];
                // '0' cells are initialized as zero, no need to explicitly set them
            }
        }

        int count = 0; // variable to accumulate the count of submatrices

        // For each position in the matrix, calculate the number of submatrices
        // that can be formed ending at (i, j)
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                // Start with a large number to minimize with the width of rows above
                int minWidth = int.MaxValue;
                // Move up from row 'i' to '0' and calculate the minWidth for submatrices ending at (i, j)
                for (int k = i; k >= 0 && minWidth > 0; --k)
                {
                    minWidth = Math.Min(minWidth, width[k][j]);
                    count += minWidth; // accumulate the count with the current minWidth
                }
            }
        }

        return count; // returning the total count of submatrices
    }
}