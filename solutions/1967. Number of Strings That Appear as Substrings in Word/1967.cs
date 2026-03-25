// Approach: Count patterns where word.Contains(pattern) is true.
// Time: O(p * n) Space: O(1)

public class Solution
{
    public int NumOfStrings(string[] patterns, string word)
    {
        return patterns.Count(pattern => word.Contains(pattern));
    }
}