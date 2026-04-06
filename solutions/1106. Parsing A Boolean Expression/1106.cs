// Approach: Stack-based parsing. Push characters onto a stack. When ')' is found,
// pop all values until the matching '(', then apply the operator ('!', '&', '|')
// on the collected boolean values and push the result back.
// Time: O(n) Space: O(n)
public class Solution
{
    public bool ParseBoolExpr(string expression)
    {
        var stack = new Stack<char>();
        foreach (char c in expression)
        {
            if (c == ',')
                continue;
            if (c != ')')
            { stack.Push(c); continue; }
            var vals = new List<char>();
            while (stack.Peek() != '(')
                vals.Add(stack.Pop());
            stack.Pop(); // pop '('
            char op = stack.Pop();
            char result = op == '!' ? (vals[0] == 't' ? 'f' : 't')
                        : op == '&' ? (vals.All(v => v == 't') ? 't' : 'f')
                                    : (vals.Any(v => v == 't') ? 't' : 'f');
            stack.Push(result);
        }
        return stack.Peek() == 't';
    }
}
