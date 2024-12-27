public class Solution
{
    public string Interpret(string command)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < command.Length;)
        {
            if (command[i] == 'G')
            {
                sb.Append("G");
                ++i;
            }
            else if (command[i + 1] == ')')
            {
                sb.Append("o");
                i += 2;
            }
            else
            {
                sb.Append("al");
                i += 4;
            }
        }
        return sb.ToString();
    }
}