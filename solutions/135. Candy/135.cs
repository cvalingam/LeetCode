public class Solution
{
    public int Candy(int[] ratings)
    {
        int n = ratings.Length;

        int ans = 0;
        int[] l = new int[n];
        int[] r = new int[n];
        Array.Fill(l, 1);
        Array.Fill(r, 1);

        for (int i = 1; i < n; ++i)
        {
            if (ratings[i] > ratings[i - 1])
                l[i] = l[i - 1] + 1;
        }

        for (int i = n - 2; i >= 0; --i)
        {
            if (ratings[i] > ratings[i + 1])
                r[i] = r[i + 1] + 1;
        }

        for (int i = 0; i < n; ++i)
            ans += Math.Max(l[i], r[i]);

        return ans;
    }
}