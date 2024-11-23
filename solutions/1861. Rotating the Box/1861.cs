public class Solution
{
    public char[][] RotateTheBox(char[][] box)
    {
        int m = box.Length;
        int n = box[0].Length;
        char[][] ans = new char[n][];
        for (int i = 0; i < n; i++)
        {
            ans[i] = new char[m];
            Array.Fill(ans[i], '.');
        }

        for (int i = 0; i < m; ++i)
        {
            for (int j = n - 1, k = n - 1; j >= 0; --j)
            {
                if (box[i][j] != '.')
                {
                    if (box[i][j] == '*')
                        k = j;
                        
                    ans[k--][m - i - 1] = box[i][j];
                }
            }
        }

        return ans;
    }
}