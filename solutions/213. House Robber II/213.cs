public class Solution
{
    public int Rob(int[] nums)
    {
        int n = nums.Length;
        List<int> arr1 = new List<int>();
        List<int> arr2 = new List<int>();

        if (n == 1)
            return nums[0];

        for (int i = 0; i < n; i++)
        {
            if (i != 0)
                arr1.Add(nums[i]);
            if (i != n - 1)
                arr2.Add(nums[i]);
        }

        int ans1 = topDown(arr1);
        int ans2 = topDown(arr2);

        return Math.Max(ans1, ans2);
    }

    private int topDown(List<int> arr)
    {
        int n = arr.Count;
        int prev = arr[0];
        int prev2 = 0;

        for (int i = 1; i < n; i++)
        {
            int pick = arr[i];
            if (i > 1)
                pick += prev2;
            int nonPick = 0 + prev;

            int cur_i = Math.Max(pick, nonPick);
            prev2 = prev;
            prev = cur_i;
        }
        return prev;
    }
}