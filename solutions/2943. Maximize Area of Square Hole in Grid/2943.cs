public class Solution
{
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars)
    {
        // Find the maximum consecutive gap in both horizontal and vertical directions
        int maxHorizontalGap = FindMaxConsecutiveGap(hBars);
        int maxVerticalGap = FindMaxConsecutiveGap(vBars);

        // The square hole's side length is limited by the smaller gap
        int maxSquareSide = Math.Min(maxHorizontalGap, maxVerticalGap);

        // Return the area of the square
        return maxSquareSide * maxSquareSide;
    }

    /// <summary>
    /// Finds the maximum number of consecutive bars that can be removed.
    /// The gap size is the number of consecutive bars plus 1.
    /// </summary>
    /// <param name="bars">Array of bar positions that can be removed</param>
    /// <returns>The maximum gap size (consecutive bars + 1)</returns>
    private int FindMaxConsecutiveGap(int[] bars)
    {
        Array.Sort(bars);

        int maxConsecutive = 1;
        int currentConsecutive = 1;

        for (int i = 1; i < bars.Length; ++i)
        {
            if (bars[i] == bars[i - 1] + 1)
            {
                currentConsecutive++;
                maxConsecutive = Math.Max(maxConsecutive, currentConsecutive);
            }
            else
                currentConsecutive = 1;
        }

        return maxConsecutive + 1;
    }
}