// Approach: A rotation of s equals goal iff goal is a substring of the doubled string s+s.
// Time: O(n) Space: O(n)

public class Solution
{
    public bool RotateString(string s, string goal)
    {
        int n = s.Length;
        int m = goal.Length;

        if (n != m)
            return false;

        string temp = s + s;
        return temp.Contains(goal);
    }
}