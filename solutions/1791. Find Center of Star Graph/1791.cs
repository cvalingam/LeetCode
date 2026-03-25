// Approach: Center node appears in both first two edges; compare endpoints directly.
// Time: O(1) Space: O(1)

public class Solution
{
    public int FindCenter(int[][] edges)
    {
        return (edges[0][0] == edges[1][0] || edges[0][0] == edges[1][1])
            ? edges[0][0]
            : edges[0][1];
    }
}