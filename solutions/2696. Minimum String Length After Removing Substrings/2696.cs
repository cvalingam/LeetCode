public class Solution
{
    public int MinLength(string s)
    {
        Stack<char> st = new Stack<char>();
        foreach (char c in s)
        {
            if (c == 'B' && isMatched(st, 'A'))
                st.Pop();
            else if (c == 'D' && isMatched(st, 'C'))
                st.Pop();
            else
                st.Push(c);
        }

        return st.Count;
    }

    private bool isMatched(Stack<char> st, char c)
    {
        return st.Count > 0 && st.Peek() == c;
    }
}