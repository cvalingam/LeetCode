public class Solution
{
    public string SmallestNumber(string pattern)
    {
        StringBuilder sb = new StringBuilder();
        Stack<char> stack = new Stack<char>();
        stack.Push('1');

        foreach (char c in pattern)
        {
            char maxSoFar = stack.Peek();
            if (c == 'I')
            {
                while (stack.Count > 0)
                {
                    maxSoFar = (char)Math.Max(maxSoFar, stack.Peek());
                    sb.Append(stack.Pop());
                }
            }
            stack.Push((char)(maxSoFar + 1));
        }

        while (stack.Count > 0)
            sb.Append(stack.Pop());

        return sb.ToString();
    }
}