public class Solution
{
    public int MincostTickets(int[] days, int[] costs)
    {
        int ans = 0;
        Queue<KeyValuePair<int, int>> last7 = new Queue<KeyValuePair<int, int>>(); // [day, cost]
        Queue<KeyValuePair<int, int>> last30 = new Queue<KeyValuePair<int, int>>();

        foreach (var day in days)
        {
            while (last7.Count > 0 && last7.Peek().Key + 7 <= day)
                last7.Dequeue();
            while (last30.Count > 0 && last30.Peek().Key + 30 <= day)
                last30.Dequeue();
            last7.Enqueue(new KeyValuePair<int, int>(day, ans + costs[1]));
            last30.Enqueue(new KeyValuePair<int, int>(day, ans + costs[2]));
            ans = Math.Min(ans + costs[0], Math.Min(last7.Count > 0 ? last7.Peek().Value : int.MaxValue, last30.Count > 0 ? last30.Peek().Value : int.MaxValue));
        }

        return ans;
    }
}