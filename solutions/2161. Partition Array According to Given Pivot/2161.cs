// Approach: Three-pass stable partition: less-than, equal, greater-than pivot.
// Time: O(n) Space: O(n)

public class Solution
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        int[] ans = new int[nums.Length];
        int i = 0; // ans' index

        foreach (int num in nums)
        {
            if (num < pivot)
                ans[i++] = num;
        }

        foreach (int num in nums)
        {
            if (num == pivot)
                ans[i++] = num;
        }

        foreach (int num in nums)
        {
            if (num > pivot)
                ans[i++] = num;
        }

        return ans;
    }
}