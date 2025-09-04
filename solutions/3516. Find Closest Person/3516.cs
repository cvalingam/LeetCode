public class Solution
{
    public int FindClosest(int x, int y, int z)
    {
        // Calculate absolute distance from x to z
        int distanceFromXToZ = Math.Abs(x - z);

        // Calculate absolute distance from y to z
        int distanceFromYToZ = Math.Abs(y - z);

        // Compare distances and return appropriate result
        if (distanceFromXToZ == distanceFromYToZ)
            return 0;  // Both x and y are equidistant from z
        else if (distanceFromXToZ < distanceFromYToZ)
            return 1;  // x is closer to z
        else
            return 2;  // y is closer to z
    }
}