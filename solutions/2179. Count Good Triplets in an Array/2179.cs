public class Solution
{
    public long GoodTriplets(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        long ans = 0;
        Dictionary<int, int> numToIndex = new Dictionary<int, int>();
        int[] arr = new int[n];
        // leftSmaller[i] := the number of arr[j] < arr[i], where 0 <= j < i
        int[] leftSmaller = new int[n];
        // rightLarger[i] := the number of arr[j] > arr[i], where i < j < n
        int[] rightLarger = new int[n];
        FenwickTree tree1 = new FenwickTree(n); // Calculates `leftSmaller`.
        FenwickTree tree2 = new FenwickTree(n); // Calculates `rightLarger`.

        for (int i = 0; i < n; ++i)
            numToIndex[nums1[i]] = i;

        // Remap each number in `nums2` to the according index in `nums1` as `arr`.
        // So the problem is to find the number of increasing triplets in `arr`.
        for (int i = 0; i < n; ++i)
            arr[i] = numToIndex[nums2[i]];

        for (int i = 0; i < n; ++i)
        {
            leftSmaller[i] = tree1.Get(arr[i]);
            tree1.Add(arr[i] + 1, 1);
        }

        for (int i = n - 1; i >= 0; --i)
        {
            rightLarger[i] = tree2.Get(n) - tree2.Get(arr[i]);
            tree2.Add(arr[i] + 1, 1);
        }

        for (int i = 0; i < n; ++i)
            ans += (long)leftSmaller[i] * rightLarger[i];

        return ans;
    }
}

class FenwickTree
{
    private int[] sums;

    public FenwickTree(int n)
    {
        sums = new int[n + 1];
    }

    public void Add(int i, int delta)
    {
        while (i < sums.Length)
        {
            sums[i] += delta;
            i += Lowbit(i);
        }
    }

    public int Get(int i)
    {
        int sum = 0;
        while (i > 0)
        {
            sum += sums[i];
            i -= Lowbit(i);
        }
        return sum;
    }

    private static int Lowbit(int i)
    {
        return i & -i;
    }
}