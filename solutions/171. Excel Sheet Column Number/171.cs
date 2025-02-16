public class Solution
{
    public int TitleToNumber(string columnTitle)
    {
        return columnTitle.Aggregate(0, (subtotal, c) => subtotal * 26 + (c - 'A' + 1));
    }
}