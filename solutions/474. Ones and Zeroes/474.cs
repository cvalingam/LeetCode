public class Solution
{
    public int FindMaxForm(string[] strs, int m, int n)
    {
        int[][] arr = findZeroesAndOnes(strs);
        int[][][] dp = new int[strs.Length][][];
        for (int i = 0; i < strs.Length; i++)
        {
            dp[i] = new int[m + 1][];
            for (int j = 0; j <= m; j++)
            {
                for (int k = 0; k <= n; k++)
                {
                    int[] dpArr = new int[n + 1];
                    Array.Fill(dpArr, -1);
                    dp[i][j] = dpArr;
                }
            }
        }

        // return OnesAndZeroesRecursion(0, m, n, arr, dp);
        return Tabulation(m, n, arr);
    }

    private int OnesAndZeroesRecursion(int ind, int m, int n, int[][] arr, int[][][] dp)
    {
        if (ind == arr.Length || m + n == 0)
            return 0;

        if (dp[ind][m][n] != -1)
            return dp[ind][m][n];

        int count0 = arr[ind][0];
        int count1 = arr[ind][1];

        int pick = 0;
        if (m >= count0 && n >= count1)
            pick = 1 + OnesAndZeroesRecursion(ind + 1, m - count0, n - count1, arr, dp);
        int notPick = OnesAndZeroesRecursion(ind + 1, m, n, arr, dp);
        return dp[ind][m][n] = Math.Max(pick, notPick);
    }

    private int Tabulation(int m, int n, int[][] arr)
    {
        int[][] dp = new int[m + 1][];
        for (int j = 0; j <= m; j++)
        {
            for (int k = 0; k <= n; k++)
            {
                int[] dpArr = new int[n + 1];
                dp[j] = dpArr;
            }
        }

        for (int ind = 0; ind < arr.Length; ind++)
        {
            int count0 = arr[ind][0];
            int count1 = arr[ind][1];
            for (int j = m; j >= count0; j--)
            {
                for (int k = n; k >= count1; k--)
                    dp[j][k] = Math.Max(1 + dp[j - count0][k - count1], dp[j][k]);
            }
        }

        return dp[m][n];
    }

    private int[][] findZeroesAndOnes(string[] str)
    {
        int len = str.Length;

        int[][] zo = new int[len][];
        for (int i = 0; i < len; i++)
            zo[i] = new int[2];

        for (int i = 0; i < len; i++)
        {
            // Console.WriteLine("String value: " + str[i]);
            for (int j = 0; j < str[i].Length; j++)
            {
                if (str[i][j] == '0')
                    zo[i][0]++;
                else
                    zo[i][1]++;
            }
            // Console.WriteLine("Zero values: " + zo[i][0]);
            // Console.WriteLine("Ones values: " + zo[i][1]);
        }

        return zo;
    }
}