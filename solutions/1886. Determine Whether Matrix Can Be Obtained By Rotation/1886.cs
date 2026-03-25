// Approach: Try all 4 rotations; return true if any matches target matrix.
// Time: O(n²) Space: O(1)

public class Solution
{
    public bool FindRotation(int[][] mat, int[][] target)
    {
        for (int i = 0; i < 4; ++i)
        {
            if (DeepEquals(mat, target))
                return true;
            Rotate(mat);
        }
        
        return false;
    }

    private void Rotate(int[][] mat)
    {
        int n = mat.Length;
        for (int i = 0, j = n - 1; i < j; ++i, --j)
        {
            int[] temp = mat[i];
            mat[i] = mat[j];
            mat[j] = temp;
        }

        for (int i = 0; i < n; ++i)
        {
            for (int j = i + 1; j < n; ++j)
            {
                int temp = mat[i][j];
                mat[i][j] = mat[j][i];
                mat[j][i] = temp;
            }
        }
    }

    private bool DeepEquals(int[][] a, int[][] b)
    {
        if (a.Length != b.Length)
            return false;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].Length != b[i].Length)
                return false;
            for (int j = 0; j < a[i].Length; j++)
            {
                if (a[i][j] != b[i][j])
                    return false;
            }
        }

        return true;
    }
}