// Approach: A second segment of ones is indicated by '01'; return !s.Contains("01").
// Time: O(n) Space: O(1)

public class Solution
{
    public bool CheckOnesSegment(string s)
    {
        return !s.Contains("01");
    }
}