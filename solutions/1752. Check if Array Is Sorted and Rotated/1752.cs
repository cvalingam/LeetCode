public class Solution
{
    public bool Check(int[] nums)
    {
        int n = nums.Length;
        int cnt = 0;

        for (int i = 0; i < n; i++)
        {
            if (nums[i] > nums[(i + 1) % n])
                cnt++;
        }

        return cnt > 1 ? false : true;
    }
}