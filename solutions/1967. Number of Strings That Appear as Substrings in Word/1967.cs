public class Solution
{
    public int NumOfStrings(string[] patterns, string word)
    {
        return patterns.Count(pattern => word.Contains(pattern));
    }
}