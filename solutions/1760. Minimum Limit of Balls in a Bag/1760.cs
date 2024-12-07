public class Solution
{
    public int MinimumSize(int[] nums, int maxOperations)
    {
        int l = 1;
        int r = nums.Max();

        while (l < r)
        {
            int m = (l + r) / 2;
            if (NumOperations(nums, m) <= maxOperations)
                r = m;
            else
                l = m + 1;
        }

        return l;
    }

    // Returns the number of operations required to make m penalty.
    private int NumOperations(int[] nums, int m)
    {
        int operations = 0;
        foreach (int num in nums)
            operations += (num - 1) / m;
        return operations;
    }
}