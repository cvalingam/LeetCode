public class Solution
{
    public int[] QueryResults(int limit, int[][] queries)
    {
        int n = queries.Length;
        int[] ans = new int[n];

        Dictionary<int, int> ballToColor = new Dictionary<int, int>();
        Dictionary<int, int> colorCount = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            int ball = queries[i][0];
            int color = queries[i][1];

            if (ballToColor.TryGetValue(ball, out int prevColor))
            {
                if (--colorCount[prevColor] == 0)
                    colorCount.Remove(prevColor);
            }
            ballToColor[ball] = color;

            if (colorCount.ContainsKey(color))
                colorCount[color]++;
            else
                colorCount[color] = 1;

            ans[i] = colorCount.Count;
        }

        return ans;
    }
}