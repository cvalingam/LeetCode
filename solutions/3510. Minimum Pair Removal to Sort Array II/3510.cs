public class Solution
{
    public int MinimumPairRemoval(int[] nums)
    {
        int n = nums.Length;
        int ans = 0;
        int inversionsCount = 0;
        int[] nextIndices = new int[n];
        int[] prevIndices = new int[n];
        long[] values = nums.Select(x => (long)x).ToArray();

        var pairSums = new SortedSet<(long sum, int index)>(
            Comparer<(long sum, int index)>.Create((a, b) =>
            {
                int cmp = a.sum.CompareTo(b.sum);
                if (cmp == 0) return a.index.CompareTo(b.index);
                return cmp;
            }));

        for (int i = 0; i < n; ++i)
        {
            nextIndices[i] = i + 1;
            prevIndices[i] = i - 1;
        }

        for (int i = 0; i < n - 1; ++i)
            pairSums.Add(((long)nums[i] + nums[i + 1], i));

        for (int i = 0; i < n - 1; ++i)
            if (nums[i + 1] < nums[i])
                ++inversionsCount;

        while (inversionsCount > 0)
        {
            ++ans;
            var smallestPair = pairSums.Min;
            pairSums.Remove(smallestPair);
            long pairSum = smallestPair.sum;
            int currIndex = smallestPair.index;
            int nextIndex = nextIndices[currIndex];
            int prevIndex = prevIndices[currIndex];

            if (prevIndex >= 0)
            {
                long oldPairSum = values[prevIndex] + values[currIndex];
                long newPairSum = values[prevIndex] + pairSum;
                pairSums.Remove((oldPairSum, prevIndex));
                pairSums.Add((newPairSum, prevIndex));
                if (values[prevIndex] > values[currIndex])
                    --inversionsCount;
                if (values[prevIndex] > pairSum)
                    ++inversionsCount;
            }

            if (nextIndex < n && values[nextIndex] < values[currIndex])
                --inversionsCount;

            int nextNextIndex = (nextIndex < n) ? nextIndices[nextIndex] : n;
            if (nextNextIndex < n)
            {
                long oldPairSum = values[nextIndex] + values[nextNextIndex];
                long newPairSum = pairSum + values[nextNextIndex];
                pairSums.Remove((oldPairSum, nextIndex));
                pairSums.Add((newPairSum, currIndex));
                if (values[nextNextIndex] < values[nextIndex])
                    --inversionsCount;
                if (values[nextNextIndex] < pairSum)
                    ++inversionsCount;
                prevIndices[nextNextIndex] = currIndex;
            }

            nextIndices[currIndex] = nextNextIndex;
            values[currIndex] = pairSum;
        }

        return ans;
    }
}