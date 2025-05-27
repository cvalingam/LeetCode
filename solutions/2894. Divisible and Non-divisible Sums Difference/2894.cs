public class Solution
{
    public int DifferenceOfSums(int n, int m)
    {
        int sum = (1 + n) * n / 2;
        int num2 = GetDivisibleSum(n, m);
        int num1 = sum - num2;
        return num1 - num2;
    }

    // Returns the sum of all the integers in [1, n] that are divisible by m.
    private int GetDivisibleSum(int n, int m)
    {
        int last = n / m * m;
        if (last == 0)
            return 0;
        int first = m;
        int count = (last - first) / m + 1;
        return (first + last) * count / 2;
    }
}