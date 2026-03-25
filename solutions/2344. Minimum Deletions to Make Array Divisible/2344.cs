// Approach: GCD of numsDivide; sort nums; count how many elements don't divide the GCD.
// Time: O(m log m + n log n) Space: O(1)

public class Solution
{
    public int MinOperations(int[] nums, int[] numsDivide)
    {
        int gcd = GetGCD(numsDivide);

        Array.Sort(nums);

        for (int i = 0; i < nums.Length; ++i)
        {
            if (gcd % nums[i] == 0)
                return i;
        }

        return -1;
    }

    private int GetGCD(int[] nums)
    {
        int g = nums[0];
        foreach (int num in nums)
            g = Gcd(g, num);
        return g;
    }

    private int Gcd(int a, int b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }
}