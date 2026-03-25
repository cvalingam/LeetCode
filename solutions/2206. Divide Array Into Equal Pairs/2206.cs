// Approach: Count occurrences; all counts must be even to form pairs.
// Time: O(n) Space: O(n)

public class Solution
{
    public bool DivideArray(int[] nums)
    {
        int[] count = new int[501];

        foreach (var num in nums)
            ++count[num];

        return count.All(c => c % 2 == 0);
    }
}