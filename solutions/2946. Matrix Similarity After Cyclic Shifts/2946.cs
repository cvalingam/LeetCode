// Approach: After k cyclic shifts, odd rows shift right and even rows shift left (or vice versa).
// A row is unchanged after k shifts only if it has period k, i.e. every element equals the one k
// positions ahead (mod n). Check each element in each row against its k-shifted counterpart.
// Time: O(n*m) Space: O(1)
public class Solution
{
    public bool AreSimilar(int[][] mat, int k)
    {
        int n = mat[0].Length;
        foreach (var row in mat)
        {
            for (int j = 0; j < n; ++j)
            {
                if (row[j] != row[(j + k) % n])
                    return false;
            }
        }

        return true;
    }
}