public class Solution
{
    public int[] FinalPrices(int[] prices)
    {
        int[] ans = (int[])prices.Clone();
        Stack<int> stack = new Stack<int>();

        for (int j = 0; j < prices.Length; ++j)
        {
            while (stack.Count > 0 && prices[j] <= prices[stack.Peek()])
                ans[stack.Pop()] -= prices[j];
            stack.Push(j);
        }

        return ans;
    }
}