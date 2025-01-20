public class Solution
{
    public int FirstCompleteIndex(int[] arr, int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        // rows[i] := the number of painted grid in the i-th row
        int[] rows = new int[m];
        // cols[j] := the number of painted grid in the j-th column
        int[] cols = new int[n];
        // numToRow[num] := the i-th row of `num` in `mat`
        int[] numToRow = new int[m * n + 1];
        // numToCol[num] := the j-th column of `num` in `mat`
        int[] numToCol = new int[m * n + 1];

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                numToRow[mat[i][j]] = i;
                numToCol[mat[i][j]] = j;
            }
        }

        for (int i = 0; i < arr.Length; ++i)
        {
            if (++rows[numToRow[arr[i]]] == n)
                return i;
            if (++cols[numToCol[arr[i]]] == m)
                return i;
        }

        throw new ArgumentException();
    }
}