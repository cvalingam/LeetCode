public class Solution
{
    public bool IsHappy(int n)
    {
        int slow = SquaredSum(n);
        int fast = SquaredSum(SquaredSum(n));

        while (slow != fast)
        {
            slow = SquaredSum(slow);
            fast = SquaredSum(SquaredSum(fast));
        }

        return slow == 1;
    }

    private int SquaredSum(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            sum += (int)Math.Pow(n % 10, 2);
            n /= 10;
        }
        return sum;
    }
}

