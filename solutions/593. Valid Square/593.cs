// Approach: Compute all 6 pairwise squared distances; a valid non-degenerate
// square has exactly 2 distinct values (4 equal sides + 2 equal diagonals).
// Time: O(1) Space: O(1)

public class Solution
{
    public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
    {
        HashSet<int> distSet = new HashSet<int>();
        int[][] points = { p1, p2, p3, p4 };

        for (int i = 0; i < 4; ++i)
        {
            for (int j = i + 1; j < 4; ++j)
                distSet.Add(Dist(points[i], points[j]));
        }

        return !distSet.Contains(0) && distSet.Count == 2;
    }

    private int Dist(int[] p1, int[] p2)
    {
        return (p1[0] - p2[0]) * (p1[0] - p2[0]) + (p1[1] - p2[1]) * (p1[1] - p2[1]);
    }
}