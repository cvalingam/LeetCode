// Approach: XOR all elements of the sequence start, start+2, start+4, ..., start+2*(n-1).
// Time: O(n) Space: O(1)

public class Solution
{
    public int XorOperation(int n, int start)
    {
        int ans = 0;
        for (int i = 0; i < n; ++i)
            ans ^= start + 2 * i;
        return ans;
    }
}