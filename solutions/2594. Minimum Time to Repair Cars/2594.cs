public class Solution
{
    public long RepairCars(int[] ranks, int cars)
    {
        long l = 0;
        long r = (long)ranks.Min() * cars * cars;

        while (l < r)
        {
            long m = (l + r) / 2;
            if (NumCarsFixed(ranks, m) >= cars)
                r = m;
            else
                l = m + 1;
        }

        return l;
    }

    private long NumCarsFixed(int[] ranks, long minutes)
    {
        long carsFixed = 0;
        foreach (var rank in ranks)
            carsFixed += (long)Math.Sqrt(minutes / rank);
        return carsFixed;
    }
}