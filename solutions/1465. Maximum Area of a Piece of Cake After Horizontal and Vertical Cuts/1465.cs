public class Solution
{
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
    {
        const int kMod = 1_000_000_007;
        Array.Sort(horizontalCuts);
        Array.Sort(verticalCuts);

        // the maximum gap of each direction
        int maxGapX = Math.Max(verticalCuts[0], w - verticalCuts[verticalCuts.Length - 1]);
        int maxGapY = Math.Max(horizontalCuts[0], h - horizontalCuts[horizontalCuts.Length - 1]);

        for (int i = 1; i < verticalCuts.Length; ++i)
            maxGapX = Math.Max(maxGapX, verticalCuts[i] - verticalCuts[i - 1]);

        for (int i = 1; i < horizontalCuts.Length; ++i)
            maxGapY = Math.Max(maxGapY, horizontalCuts[i] - horizontalCuts[i - 1]);

        return (int)((long)maxGapX * maxGapY % kMod);
    }
}