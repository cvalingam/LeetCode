public class Solution
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        List<string> ans = new List<string>();
        Dfs(turnedOn, 0, 0, 0, ans);
        return ans;
    }

    private int[] hours = new int[] { 1, 2, 4, 8 };
    private int[] minutes = new int[] { 1, 2, 4, 8, 16, 32 };

    private void Dfs(int turnedOn, int s, int h, int m, List<string> ans)
    {
        if (turnedOn == 0)
        {
            string time = h + ":" + (m < 10 ? "0" : "") + m;
            ans.Add(time);
            return;
        }

        for (int i = s; i < hours.Length + minutes.Length; ++i)
        {
            if (i < 4 && h + hours[i] < 12)
                Dfs(turnedOn - 1, i + 1, h + hours[i], m, ans);
            else if (i >= 4 && m + minutes[i - 4] < 60)
                Dfs(turnedOn - 1, i + 1, h, m + minutes[i - 4], ans);
        }
    }
}