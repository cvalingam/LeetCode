public class Solution
{
    public long MinimumCost(int[] nums, int k, int dist)
    {
        long windowSum = 0;
        Multiset selected = new Multiset();
        Multiset candidates = new Multiset();

        for (int i = 1; i <= dist + 1; ++i)
        {
            windowSum += nums[i];
            selected.Add(nums[i]);
        }

        windowSum = Balance(windowSum, selected, candidates, k);
        long minWindowSum = windowSum;

        for (int i = dist + 2; i < nums.Length; ++i)
        {
            int outOfScope = nums[i - dist - 1];
            if (selected.Contains(outOfScope))
            {
                windowSum -= outOfScope;
                selected.Remove(outOfScope);
            }
            else
                candidates.Remove(outOfScope);

            if (nums[i] < selected.Max())
            { // nums[i] is a better number.
                windowSum += nums[i];
                selected.Add(nums[i]);
            }
            else
                candidates.Add(nums[i]);

            windowSum = Balance(windowSum, selected, candidates, k);
            minWindowSum = Math.Min(minWindowSum, windowSum);
        }

        return nums[0] + minWindowSum;
    }

    // Returns the updated `windowSum` by balancing the multiset `selected` to
    // keep the top k - 1 numbers.
    private long Balance(long windowSum, Multiset selected, Multiset candidates, int k)
    {
        while (selected.Size() < k - 1)
        {
            int minCandidate = candidates.Min();
            windowSum += minCandidate;
            selected.Add(minCandidate);
            candidates.Remove(minCandidate);
        }
        while (selected.Size() > k - 1)
        {
            int maxSelected = selected.Max();
            windowSum -= maxSelected;
            selected.Remove(maxSelected);
            candidates.Add(maxSelected);
        }
        return windowSum;
    }
}

class Multiset
{
    private SortedDictionary<int, int> map = new SortedDictionary<int, int>();
    private int sz = 0;

    public void Add(int num)
    {
        if (map.ContainsKey(num))
            map[num]++;
        else
            map[num] = 1;
        sz++;
    }

    public void Remove(int num)
    {
        if (map.ContainsKey(num))
        {
            map[num]--;
            if (map[num] == 0)
                map.Remove(num);
        }
        sz--;
    }

    public int Min()
    {
        return map.First().Key;
    }

    public int Max()
    {
        return map.Last().Key;
    }

    public int Size()
    {
        return sz;
    }

    public bool Contains(int num)
    {
        return map.ContainsKey(num);
    }
}