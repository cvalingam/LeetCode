public class Solution
{
    public void WiggleSort(int[] nums)
    {
        int n = nums.Length;
        int median = FindKthLargest(nums, (n + 1) / 2);
        for (int i = 0, j = 0, k = n - 1; i <= k;)
        {
            if (nums[A(i, n)] > median)
                Swap(nums, A(i++, n), A(j++, n));
            else if (nums[A(i, n)] < median)
                Swap(nums, A(i, n), A(k--, n));
            else
                ++i;
        }
    }

    private int A(int i, int n)
    {
        return (1 + 2 * i) % (n | 1);
    }

    private int FindKthLargest(int[] nums, int k)
    {
        return QuickSelect(nums, 0, nums.Length - 1, k);
    }

    private int QuickSelect(int[] nums, int l, int r, int k)
    {
        int pivot = nums[r];

        int nextSwapped = l;
        for (int i = l; i < r; ++i)
        {
            if (nums[i] >= pivot)
                Swap(nums, nextSwapped++, i);
        }
        Swap(nums, nextSwapped, r);

        int count = nextSwapped - l + 1; // the number of `nums` >= pivot
        if (count == k)
            return nums[nextSwapped];
        if (count > k)
            return QuickSelect(nums, l, nextSwapped - 1, k);

        return QuickSelect(nums, nextSwapped + 1, r, k - count);
    }

    private void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}