// Approach: Count unmatched ']' after cancelling matched pairs; answer = ceil(unmatched / 2).
// Time: O(n) Space: O(1)

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