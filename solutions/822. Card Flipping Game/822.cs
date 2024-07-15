public class Solution
{
    public int Flipgame(int[] fronts, int[] backs)
    {
        const int kMax = 2001;
        int ans = kMax;
        HashSet<int> same = new HashSet<int>();

        for (int i = 0; i < fronts.Length; ++i)
            if (fronts[i] == backs[i])
                same.Add(fronts[i]);

        foreach (int front in fronts)
            if (!same.Contains(front))
                ans = Math.Min(ans, front);

        foreach (int back in backs)
            if (!same.Contains(back))
                ans = Math.Min(ans, back);

        return ans == kMax ? 0 : ans;
    }
}

