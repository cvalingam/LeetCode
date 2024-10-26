public class Solution
{
    public long MatrixSumQueries(int n, int[][] queries)
    {
        HashSet<int> rows = new HashSet<int>();
        HashSet<int> cols = new HashSet<int>();

        int l = queries.Length;
        long result = 0;
        for (int i = l - 1; i >= 0; i--)
        {
            int type = queries[i][0];
            int index = queries[i][1];
            int val = queries[i][2];
            if (type == 1)
            {
                if (!cols.Contains(index))
                {
                    cols.Add(index);
                    result += val * (n - rows.Count);
                }
            }
            else
            {
                if (!rows.Contains(index))
                {
                    rows.Add(index);
                    result += val * (n - cols.Count);
                }
            }
        }

        return result;
    }
}