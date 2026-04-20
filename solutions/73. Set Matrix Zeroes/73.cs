// Approach: Use the first row and first column of the matrix as in-place zero flags.
// First, record whether row 0 or column 0 themselves need to be zeroed (using separate booleans).
// Then scan the rest of the matrix: if matrix[i][j] == 0, set matrix[i][0] = 0 and matrix[0][j] = 0.
// Second pass: use the flag values in row 0 and column 0 to zero out rows and columns.
// Finally, zero row 0 and column 0 if their original booleans were set.
// This avoids O(m + n) extra space by repurposing the matrix's own first row/column as flag storage.
// Time: O(m x n) Space: O(1).

public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        bool isCol = false;

        for (int i = 0; i < m; i++)
        {
            if (matrix[i][0] == 0)
                isCol = true;

            for (int j = 1; j < n; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    matrix[i][j] = 0;
            }
        }

        if (matrix[0][0] == 0)
        {
            for (int j = 0; j < n; j++)
                matrix[0][j] = 0;
        }

        if (isCol)
        {
            for (int i = 0; i < m; i++)
                matrix[i][0] = 0;
        }
    }
}