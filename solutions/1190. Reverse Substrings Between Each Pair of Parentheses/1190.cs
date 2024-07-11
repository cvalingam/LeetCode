public class Solution
{
    public string ReverseParentheses(string s)
    {
        var st = new Stack<int>();
        var sb = new StringBuilder();

        foreach (char ch in s)
        {
            if (ch == '(')
                st.Push(sb.Length);
            else if (ch == ')')
            {
                var reversed = new StringBuilder();
                for (int sz = sb.Length - st.Pop(); sz > 0; sz--)
                {
                    reversed.Append(sb[sb.Length - 1]);
                    sb.Remove(sb.Length - 1, 1);
                }
                sb.Append(reversed);
            }
            else
                sb.Append(ch);
        }

        return sb.ToString();
    }
}