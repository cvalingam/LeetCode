public class Solution
{
    public int MinPartitions(string n)
    {
        return n.Max(c => c - '0');
    }
}