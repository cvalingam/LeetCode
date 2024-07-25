public class Solution
{
    public int[] SortArray(int[] nums)
    {
        MergeSort(nums, 0, nums.Length - 1);

        return nums;
    }

    private void MergeSort(int[] A, int l, int r)
    {
        if (l >= r)
            return;

        int m = (l + r) / 2;

        MergeSort(A, l, m);
        MergeSort(A, m + 1, r);
        Merge(A, l, m, r);
    }

    private void Merge(int[] A, int l, int m, int r)
    {
        int[] sorted = new int[r - l + 1];
        int i = l, k = 0, j = m + 1;

        while (i <= m && j <= r)
        {
            if (A[i] < A[j])
                sorted[k++] = A[i++];
            else
                sorted[k++] = A[j++];
        }

        while (i <= m)
            sorted[k++] = A[i++];

        while (j <= r)
            sorted[k++] = A[j++];

        Array.Copy(sorted, 0, A, l, sorted.Length);
    }
}