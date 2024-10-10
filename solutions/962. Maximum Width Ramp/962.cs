public class Solution
{
    public int MaxWidthRamp(int[] nums)
    {
        int ans = 0;
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < nums.Length; ++i)
        {
            if (stack.Count == 0 || nums[i] < nums[stack.Peek()])
                stack.Push(i);
        }

        for (int i = nums.Length - 1; i > ans; --i)
        {
            while (stack.Count > 0 && nums[i] >= nums[stack.Peek()])
                ans = Math.Max(ans, i - stack.Pop());
        }

        return ans;
    }
}