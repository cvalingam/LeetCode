// Approach: Only perfect-square positions have an odd number of divisors
// and remain on after all toggles; return floor(√n).
// Time: O(1) Space: O(1)

public class Solution
{
    public int BulbSwitch(int n)
    {
        return (int)Math.Sqrt(n);
    }
}