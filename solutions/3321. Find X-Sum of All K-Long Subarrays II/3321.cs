public class Solution
{
    private long windowSum = 0;

    public long[] FindXSum(int[] nums, int k, int x)
    {
        long[] ans = new long[nums.Length - k + 1];
        var count = new Dictionary<long, long>();

        var top = new SortedSet<(long Key, long Value)>(
            Comparer<(long Key, long Value)>.Create((a, b) =>
            {
                int cmp = a.Key.CompareTo(b.Key);
                if (cmp == 0) return a.Value.CompareTo(b.Value);
                return cmp;
            }));

        var bot = new SortedSet<(long Key, long Value)>(
            Comparer<(long Key, long Value)>.Create((a, b) =>
            {
                int cmp = a.Key.CompareTo(b.Key);
                if (cmp == 0) return a.Value.CompareTo(b.Value);
                return cmp;
            }));

        for (int i = 0; i < nums.Length; ++i)
        {
            Update(nums[i], 1, count, top, bot);
            if (i >= k)
                Update(nums[i - k], -1, count, top, bot);

            // Move the bottom elements to the top if needed.
            while (bot.Count > 0 && top.Count < x)
            {
                var pair = bot.Max;
                bot.Remove(pair);
                top.Add(pair);
                windowSum += pair.Value * pair.Key;
            }

            // Swap the bottom and top elements if needed.
            while (bot.Count > 0 && top.Count > 0)
            {
                var botLast = bot.Max;
                var topFirst = top.Min;
                if (botLast.Key > topFirst.Key || (botLast.Key == topFirst.Key && botLast.Value > topFirst.Value))
                {
                    bot.Remove(botLast);
                    top.Remove(topFirst);
                    top.Add(botLast);
                    bot.Add(topFirst);
                    windowSum += botLast.Value * botLast.Key;
                    windowSum -= topFirst.Value * topFirst.Key;
                }
                else
                    break;
            }

            if (i >= k - 1)
                ans[i - k + 1] = windowSum;
        }
        return ans;
    }

    private void Update(int num, in long freq, Dictionary<long, long> count,
                        SortedSet<(long Key, long Value)> top, SortedSet<(long Key, long Value)> bot)
    {
        if (count.TryGetValue(num, out long oldCount) && oldCount > 0)
        {
            var pair = (oldCount, num);
            if (bot.Remove(pair))
            {
                // Do nothing.
            }
            else if (top.Remove(pair))
                windowSum -= num * oldCount;
        }
        count[num] = count.GetValueOrDefault(num) + freq;
        if (count[num] > 0)
            bot.Add((count[num], num));
    }
}