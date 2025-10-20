public class Solution
{
    public int FinalValueAfterOperations(string[] operations)
    {
        int result = 0;
        foreach (string operation in operations)
        {
            if (operation[1] == '+')
                result += 1;
            else
                result -= 1;
        }
        return result;
    }
}