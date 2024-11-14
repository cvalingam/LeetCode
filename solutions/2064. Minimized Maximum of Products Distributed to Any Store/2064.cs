public class Solution
{
    public int MinimizedMaximum(int n, int[] quantities)
    {
        int l = 1;
        int r = quantities.Max();

        while (l < r)
        {
            int m = (l + r) / 2;
            if (NumStores(quantities, m) <= n)
                r = m;
            else
                l = m + 1;
        }

        return l;
    }

    private int NumStores(int[] quantities, int m)
    {
        // ceil(q / m)
        return quantities.Sum(q => (q - 1) / m + 1);
    }
}