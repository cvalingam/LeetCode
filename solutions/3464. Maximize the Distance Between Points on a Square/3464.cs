public class Solution
{
    // Rich Explanation:
    // We need the maximum value d such that we can pick k boundary points and keep
    // pairwise Manhattan distance constraints while walking around the square boundary.
    //
    // Step 1: Linearize geometry
    // - Split points by boundary (left, top, right, bottom) and sort each boundary
    //   in traversal order.
    // - Concatenate them to get one clockwise perimeter order.
    //
    // Step 2: Binary search answer d
    // - If a distance d is feasible, then every d' <= d is also feasible.
    // - This monotonicity allows binary search on [0, side].
    //
    // Step 3: Feasibility check for fixed d (IsValidDistance)
    // - Scan ordered points once.
    // - Maintain deque states: (start point, end point, chain length).
    // - While a state's end is far enough from current point, we can try extending
    //   that chain by the current point.
    // - Keep the best extension candidate and push new state.
    //
    // Why deque gives linear time for one check:
    // - Every state is inserted once and removed once.
    // - So IsValidDistance is O(m), where m = number of points.
    //
    // Overall complexity:
    // - Sorting boundary points: O(m log m)
    // - Binary search iterations: O(log side)
    // - Each iteration uses O(m) feasibility check
    // Total: O(m log m + m log side)
    // Space: O(m)
    public int MaxDistance(int side, int[][] points, int k)
    {
        var ordered = GetOrderedPoints(side, points);
        int l = 0;
        int r = side;

        while (l < r)
        {
            int m = (l + r + 1) / 2;
            if (IsValidDistance(ordered, k, m))
                l = m;
            else
                r = m - 1;
        }

        return l;
    }

    private record Sequence(int StartX, int StartY, int EndX, int EndY, int Length);

    // Returns true if we can select `k` points such that the minimum Manhattan
    // distance between any two consecutive chosen points is at least `d`.
    private bool IsValidDistance(List<int[]> ordered, int k, int d)
    {
        var dq = new LinkedList<Sequence>();
        dq.AddFirst(new Sequence(
            ordered[0][0], ordered[0][1], ordered[0][0], ordered[0][1], 1));
        int maxLength = 1;

        for (int i = 1; i < ordered.Count; ++i)
        {
            int x = ordered[i][0];
            int y = ordered[i][1];
            int startX = x;
            int startY = y;
            int length = 1;

            while (dq.Count > 0 &&
                   (Math.Abs(x - dq.First.Value.EndX) + Math.Abs(y - dq.First.Value.EndY) >= d))
            {
                var first = dq.First.Value;
                if (Math.Abs(x - first.StartX) + Math.Abs(y - first.StartY) >= d &&
                    first.Length + 1 >= length)
                {
                    startX = first.StartX;
                    startY = first.StartY;
                    length = first.Length + 1;
                    maxLength = Math.Max(maxLength, length);
                }
                dq.RemoveFirst();
            }
            dq.AddLast(new Sequence(startX, startY, x, y, length));
        }

        return maxLength >= k;
    }

    // Returns the ordered points on the perimeter of a square of side length
    // `side`, starting from left, top, right, and bottom boundaries.
    private List<int[]> GetOrderedPoints(int side, int[][] points)
    {
        var left = new List<int[]>();
        var top = new List<int[]>();
        var right = new List<int[]>();
        var bottom = new List<int[]>();

        foreach (var point in points)
        {
            int x = point[0];
            int y = point[1];
            if (x == 0 && y > 0)
                left.Add(point);
            else if (x > 0 && y == side)
                top.Add(point);
            else if (x == side && y < side)
                right.Add(point);
            else
                bottom.Add(point);
        }

        left.Sort((a, b) => a[1].CompareTo(b[1]));
        top.Sort((a, b) => a[0].CompareTo(b[0]));
        right.Sort((a, b) => b[1].CompareTo(a[1]));
        bottom.Sort((a, b) => b[0].CompareTo(a[0]));

        var ordered = new List<int[]>();
        ordered.AddRange(left);
        ordered.AddRange(top);
        ordered.AddRange(right);
        ordered.AddRange(bottom);
        return ordered;
    }
}