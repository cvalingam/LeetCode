// Approach: Treat the column title as a base-26 number (A = 1…Z = 26),
// accumulating the result left to right with multiplication.
// Time: O(n) Space: O(1)

public class Solution
{
    public int TitleToNumber(string columnTitle)
    {
        return columnTitle.Aggregate(0, (subtotal, c) => subtotal * 26 + (c - 'A' + 1));
    }
}