public class Solution
{
    public bool IsPowerOfThree(int n)
    {
        if (n == 0)
            return false;

        while (n % 3 == 0)
            n /= 3;

        return n == 1;
    }
}

public class Solution1
{
    public bool IsPowerOfThree(int n)
    {
        // 1162261467 is the maximum integer that is a power of three
        // (it is 3^19, as 3^20 is bigger than int).
        // If 'n' is a power of three, it must divide this number without a remainder.

        // The condition 'n > 0' ensures that 'n' is positive,
        // because negative numbers and zero cannot be powers of three.
        return n > 0 && 1162261467 % n == 0;
    }
}