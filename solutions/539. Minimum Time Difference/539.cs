public class Solution
{
    public int FindMinDifference(IList<string> timePoints)
    {
        int ans = 24 * 60;
        int first = 24 * 60;

        bool[] bucket = new bool[24 * 60];

        foreach (var timePoint in timePoints)
        {
            int num = int.Parse(timePoint.Substring(0, 2)) * 60 + int.Parse(timePoint.Substring(3));
            first = Math.Min(first, num);
            if (bucket[num])
                return 0;
            bucket[num] = true;
        }

        int prev = first;

        for (int i = first + 1; i < bucket.Length; ++i)
        {
            if (bucket[i])
            {
                ans = Math.Min(ans, i - prev);
                prev = i;
            }
        }

        return Math.Min(ans, 24 * 60 - prev + first);
    }
}