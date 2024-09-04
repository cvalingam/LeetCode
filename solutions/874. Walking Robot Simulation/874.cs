public class Solution
{
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        int d = 0; // 0 := north, 1 := east, 2 := south, 3 := west
        int x = 0, y = 0, ans = 0;

        HashSet<(int, int)> obstaclesSet = new HashSet<(int, int)>();

        foreach (var o in obstacles)
            obstaclesSet.Add((o[0], o[1]));

        foreach (int c in commands)
        {
            if (c == -1)
                d = (d + 1) % 4;
            else if (c == -2)
                d = (d + 3) % 4;
            else
            {
                for (int step = 0; step < c; step++)
                {
                    if (obstaclesSet.Contains((x + dirs[d][0], y + dirs[d][1])))
                        break;

                    x += dirs[d][0];
                    y += dirs[d][1];
                }
            }
            ans = Math.Max(ans, x * x + y * y);
        }

        return ans;
    }
}