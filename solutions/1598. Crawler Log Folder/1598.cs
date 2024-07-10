public class Solution
{
    public int MinOperations(string[] logs)
    {
        int ops = 0;

        foreach (string log in logs)
        {
            if (log == "./")
                continue;

            if (log == "../")
            {
                if (ops > 0)
                    ops--;
            }
            else
                ops++;
        }

        return ops;
    }
}