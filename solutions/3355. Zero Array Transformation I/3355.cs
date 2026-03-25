// Approach: Difference array; apply all query decrements; check all elements reducible to 0.
// Time: O(n + q) Space: O(n)

public class Solution
{
    public bool IsZeroArray(int[] nums, int[][] queries)
    {
        int[] line = new int[nums.Length + 1];
        int decrement = 0;

        foreach (var query in queries)
        {
            int l = query[0];
            int r = query[1];
            line[l]++;
            line[r + 1]--;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            decrement += line[i];
            if (decrement < nums[i])
                return false;
        }

        return true;
    }
}