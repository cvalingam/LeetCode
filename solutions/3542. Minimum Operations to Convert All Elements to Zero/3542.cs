public class Solution
{
    public int MinOperations(int[] nums)
    {
        int ans = 0;
        Stack<int> stack = new Stack<int>();
        stack.Push(0);

        foreach (int num in nums)
        {
            while (stack.Count > 0 && stack.Peek() > num)
                stack.Pop();
            if (stack.Count == 0 || stack.Peek() < num)
            {
                ++ans;
                stack.Push(num);
            }
        }

        return ans;
    }
}