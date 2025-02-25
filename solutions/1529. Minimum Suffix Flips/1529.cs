public class Solution
{
    public int MinFlips(string target)
    {
        int ans = 0;
        int state = 0;

        foreach (char c in target)
        {
            if (c - '0' != state)
            {
                state = c - '0';
                ++ans;
            }
        }

        return ans;
    }
}