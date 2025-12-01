public class Solution
{
    public long MaxRunTime(int n, int[] batteries)
    {
        long left = 0;
        long right = 0;
        foreach (int battery in batteries)
            right += battery;

        while (left < right)
        {
            long mid = (left + right + 1) >> 1;

            long totalUsableCapacity = 0;
            foreach (int battery in batteries)
                totalUsableCapacity += Math.Min(mid, battery);

            if (totalUsableCapacity >= n * mid)
                left = mid;
            else
                right = mid - 1;
        }

        return left;
    }
}