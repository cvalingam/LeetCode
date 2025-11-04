public class Solution
{
    private int windowSum = 0;

    public int[] FindXSum(int[] nums, int k, int x)
    {
        int[] ans = new int[nums.Length - k + 1];
        var count = new Dictionary<int, int>();

        // Comparer for pairs (count, num) - sort by count ascending, then num ascending
        var comparer = Comparer<(int count, int num)>.Create((a, b) =>
        {
            int cmp = a.count.CompareTo(b.count);
            if (cmp == 0) return a.num.CompareTo(b.num);
            return cmp;
        });

        var top = new SortedSet<(int count, int num)>(comparer);
        var bot = new SortedSet<(int count, int num)>(comparer);

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
                windowSum += pair.num * pair.count;
            }

            // Swap the bottom and top elements if needed.
            while (bot.Count > 0 && top.Count > 0)
            {
                var botLast = bot.Max;
                var topFirst = top.Min;

                if (botLast.count > topFirst.count ||
                    (botLast.count == topFirst.count && botLast.num > topFirst.num))
                {
                    bot.Remove(botLast);
                    top.Remove(topFirst);
                    top.Add(botLast);
                    bot.Add(topFirst);
                    windowSum += botLast.num * botLast.count;
                    windowSum -= topFirst.num * topFirst.count;
                }
                else
                    break;
            }

            if (i >= k - 1)
                ans[i - k + 1] = windowSum;
        }
        return ans;
    }

    private void Update(int num, int freq, Dictionary<int, int> count,
                        SortedSet<(int count, int num)> top, SortedSet<(int count, int num)> bot)
    {
        if (count.TryGetValue(num, out int oldCount) && oldCount > 0)
        {
            var oldPair = (oldCount, num);
            if (bot.Remove(oldPair))
            {
                // Do nothing
            }
            else if (top.Remove(oldPair))
                windowSum -= num * oldCount;
        }
        count[num] = count.GetValueOrDefault(num) + freq;
        if (count[num] > 0)
            bot.Add((count[num], num));
    }
}