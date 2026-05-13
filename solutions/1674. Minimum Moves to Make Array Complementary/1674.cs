// Approach: Use a difference array (delta) to track move-count changes as target sum increases from 2 to 2*limit.
// For each pair (nums[i], nums[n-1-i]), determine the range of targets where one or both values need to change.
// Incrementally update the move count using cumulative deltas; track the minimum.
// Time: O(n + limit) Space: O(limit)

public class Solution
{
    public int MinMoves(int[] nums, int limit)
    {
        int n = nums.Length;
        int ans = n;
        // delta[i] := the number of moves needed when target goes from i - 1 to i
        int[] delta = new int[limit * 2 + 2];

        for (int i = 0; i < n / 2; ++i)
        {
            int a = nums[i];
            int b = nums[n - 1 - i];
            delta[Math.Min(a, b) + 1]--;
            delta[a + b]--;
            delta[a + b + 1]++;
            delta[Math.Max(a, b) + limit + 1]++;
        }

        // Initially, we need `moves` when the target is 2.
        for (int i = 2, moves = n; i <= limit * 2; ++i)
        {
            moves += delta[i];
            ans = Math.Min(ans, moves);
        }

        return ans;
    }
}