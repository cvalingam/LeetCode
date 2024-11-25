public class Solution
{
    public int SlidingPuzzle(int[][] board)
    {
        int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        int m = 2;
        int n = 3;
        string goal = "123450";
        StringBuilder startSb = new StringBuilder();

        for (int i = 0; i < m; ++i)
            for (int j = 0; j < n; ++j)
                startSb.Append((char)('0' + board[i][j]));

        string start = startSb.ToString();
        if (start.Equals(goal))
            return 0;

        Queue<string> q = new Queue<string>(new List<string> { start });
        HashSet<string> seen = new HashSet<string>(new List<string> { start });

        for (int step = 1; q.Count > 0; ++step)
        {
            for (int sz = q.Count; sz > 0; --sz)
            {
                string s = q.Dequeue();
                int zeroIndex = s.IndexOf("0");
                int i = zeroIndex / n;
                int j = zeroIndex % n;
                foreach (var dir in dirs)
                {
                    int x = i + dir[0];
                    int y = j + dir[1];
                    
                    if (x < 0 || x == m || y < 0 || y == n)
                        continue;

                    int swappedIndex = x * n + y;
                    StringBuilder sb = new StringBuilder(s);
                    sb[zeroIndex] = s[swappedIndex];
                    sb[swappedIndex] = s[zeroIndex];
                    string t = sb.ToString();

                    if (t.Equals(goal))
                        return step;

                    if (!seen.Contains(t))
                    {
                        q.Enqueue(t);
                        seen.Add(t);
                    }
                }
            }
        }

        return -1;
    }
}