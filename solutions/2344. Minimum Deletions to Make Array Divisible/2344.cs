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