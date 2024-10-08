public class Solution
{
    public int MinSwaps(string s)
    {
        // Cancel out all the matched pairs, then we'll be left with "]]]..[[[".
        // The answer is ceil(the number of unmatched pairs / 2).
        int unmatched = 0;

        foreach (char c in s)
        {
            if (c == '[')
            {
                unmatched++;
            }
            else if (unmatched > 0)
            { // c == ']' and there's a match.
                unmatched--;
            }
        }

        return (unmatched + 1) / 2;
    }
}