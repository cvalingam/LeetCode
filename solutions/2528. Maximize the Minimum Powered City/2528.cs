public class Solution
{
    public long MaxPower(int[] stations, int r, int k)
    {
        long left = stations.Min();
        long right = stations.Select(s => (long)s).Sum() + k + 1;

        while (left < right)
        {
            long mid = (left + right) / 2;
            if (Check((int[])stations.Clone(), r, k, mid))
                left = mid + 1;
            else
                right = mid;
        }

        return left - 1;
    }

    // Returns true if each city can have at least `minPower`.
    private bool Check(int[] stations, int r, int additionalStations, long minPower)
    {
        int n = stations.Length;
        long power = 0;

        for (int i = 0; i < r; ++i)
            power += stations[i];

        for (int i = 0; i < n; ++i)
        {
            if (i + r < n)
                power += stations[i + r]; // power = sum(stations[i - r..i + r])
            if (power < minPower)
            {
                long requiredPower = minPower - power;
                if (requiredPower > additionalStations)
                    return false;
                stations[Math.Min(n - 1, i + r)] += (int)requiredPower;
                additionalStations -= (int)requiredPower;
                power += requiredPower;
            }
            if (i - r >= 0)
                power -= stations[i - r];
        }

        return true;
    }
}