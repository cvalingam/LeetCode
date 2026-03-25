// Approach: Use a stack; unmatched '(' and ')' characters remain; the stack size at the end equals the number of additions needed.
// Time: O(n) Space: O(n)

public class Solution
{
    public int MinAddToMakeValid(string s)
    {
        Stack<char> st = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
                st.Push(s[i]);
            else
            {
                if (st.Count > 0 && st.Peek() == '(')
                    st.Pop();
                else
                    st.Push(s[i]);
            }
        }

        return st.Count;
    }
}