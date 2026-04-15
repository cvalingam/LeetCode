// Approach: Expand outward from startIndex by distance i and check both clockwise and
// counterclockwise positions in the circular array. The first match gives the minimum
// distance by construction.
// Time: O(n) Space: O(1)
public class Solution
{
    public int ClosestTarget(string[] words, string target, int startIndex)
    {
        int n = words.Length;

        for (int i = 0; i < n; ++i)
        {
            if (words[(startIndex + i + n) % n] == target)
                return i;
            if (words[(startIndex - i + n) % n] == target)
                return i;
        }

        return -1;
    }
}
