// Approach: Two-pass prefix scan (left-to-right then right-to-left) accumulating count and moves.
// Time: O(n) Space: O(n)

public class Solution
{
    public int[] MinOperations(string boxes)
    {
        int[] ans = new int[boxes.Length];

        for (int i = 0, count = 0, moves = 0; i < boxes.Length; ++i)
        {
            ans[i] += moves;
            count += boxes[i] == '1' ? 1 : 0;
            moves += count;
        }

        for (int i = boxes.Length - 1, count = 0, moves = 0; i >= 0; --i)
        {
            ans[i] += moves;
            count += boxes[i] == '1' ? 1 : 0;
            moves += count;
        }

        return ans;
    }
}