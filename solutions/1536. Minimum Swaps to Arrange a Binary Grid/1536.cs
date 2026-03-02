public class Solution
{
    public int MinSwaps(int[][] grid)
    {
        int n = grid.Length;
        int ans = 0;
        // suffixZeros[i] := the number of suffix zeros in the i-th row
        int[] suffixZeros = new int[n];

        for (int i = 0; i < grid.Length; ++i)
            suffixZeros[i] = GetSuffixZeroCount(grid[i]);

        for (int i = 0; i < n; ++i)
        {
            int neededZeros = n - 1 - i;
            // Get the first row with suffix zeros >= `neededZeros` in suffixZeros[i:..n).
            int j = GetFirstRowWithEnoughZeros(suffixZeros, i, neededZeros);
            if (j == -1)
                return -1;
            // Move the rows[j] to the rows[i].
            for (int k = j; k > i; --k)
                suffixZeros[k] = suffixZeros[k - 1];
            ans += j - i;
        }

        return ans;
    }

    private int GetSuffixZeroCount(int[] row)
    {
        for (int i = row.Length - 1; i >= 0; --i)
        {
            if (row[i] == 1)
                return row.Length - i - 1;
        }
        
        return row.Length;
    }

    // Returns first row that has suffix zeros >= `neededZeros` in suffixZeros[i:..n).
    private int GetFirstRowWithEnoughZeros(int[] suffixZeros, int i, int neededZeros)
    {
        for (int j = i; j < suffixZeros.Length; ++j)
        {
            if (suffixZeros[j] >= neededZeros)
                return j;
        }

        return -1;
    }
}