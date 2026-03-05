public class Solution
{
    public int MinOperations(string s)
    {
        int cost10 = 0; // the cost to make s "1010"

        for (int i = 0; i < s.Length; ++i)
        {
            if ((s[i] - '0') == i % 2)
                ++cost10;
        }

        int cost01 = s.Length - cost10; // the cost to make s "0101"
        return Math.Min(cost10, cost01);
    }
}