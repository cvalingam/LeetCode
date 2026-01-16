public class Solution
{
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
    {
        const int MOD = 1_000_000_007;

        Array.Resize(ref hFences, hFences.Length + 2);
        Array.Resize(ref vFences, vFences.Length + 2);

        hFences[hFences.Length - 2] = 1;
        hFences[hFences.Length - 1] = m;
        vFences[vFences.Length - 2] = 1;
        vFences[vFences.Length - 1] = n;

        Array.Sort(hFences);
        Array.Sort(vFences);

        var hGaps = GetGaps(hFences);
        var vGaps = GetGaps(vFences);
        int maxGap = -1;

        foreach (var hGap in hGaps)
        {
            if (vGaps.Contains(hGap))
                maxGap = Math.Max(maxGap, hGap);
        }

        return maxGap == -1 ? -1 : (int)(((long)maxGap * maxGap) % MOD);
    }

    private HashSet<int> GetGaps(int[] fences)
    {
        var gaps = new HashSet<int>();
        for (int i = 0; i < fences.Length; ++i)
        {
            for (int j = 0; j < i; ++j)
                gaps.Add(fences[i] - fences[j]);
        }
        
        return gaps;
    }
}