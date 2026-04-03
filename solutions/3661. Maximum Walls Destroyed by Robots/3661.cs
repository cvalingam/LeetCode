// Approach: Sort robots by position and walls. For each robot (right to left), use DFS+memo
// to decide whether it destroys walls on its left side or right side.
// Binary search counts walls in each robot's reachable range after resolving overlaps.
// Time: O(n log n + w log w) Space: O(n)
public class Solution
{
    private int?[][] f;
    private int[][] arr;
    private int[] walls;
    private int n;

    public int MaxWalls(int[] robots, int[] distance, int[] walls)
    {
        n = robots.Length;
        arr = new int[n][];
        for (int i = 0; i < n; i++)
        {
            arr[i] = new int[2];
            arr[i][0] = robots[i];
            arr[i][1] = distance[i];
        }
        arr = arr.OrderBy(a => a[0]).ToArray();
        Array.Sort(walls);
        this.walls = walls;
        f = new int?[n][];
        for (int i = 0; i < n; i++)
            f[i] = new int?[2];
        return Dfs(n - 1, 1);
    }

    private int Dfs(int i, int j)
    {
        if (i < 0)
            return 0;

        if (f[i][j].HasValue)
            return f[i][j].Value;

        int left = arr[i][0] - arr[i][1];
        if (i > 0)
            left = Math.Max(left, arr[i - 1][0] + 1);

        int l = LowerBound(walls, left);
        int r = LowerBound(walls, arr[i][0] + 1);
        int ans = Dfs(i - 1, 0) + (r - l);

        int right = arr[i][0] + arr[i][1];
        if (i + 1 < n)
        {
            if (j == 0)
                right = Math.Min(right, arr[i + 1][0] - arr[i + 1][1] - 1);
            else
                right = Math.Min(right, arr[i + 1][0] - 1);
        }
        l = LowerBound(walls, arr[i][0]);
        r = LowerBound(walls, right + 1);
        ans = Math.Max(ans, Dfs(i - 1, 1) + (r - l));
        f[i][j] = ans;

        return ans;
    }

    private int LowerBound(int[] arr, int target)
    {
        int idx = Array.BinarySearch(arr, target);
        if (idx < 0)
            return ~idx;

        return idx;
    }
}