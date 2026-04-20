// Approach: Apply Floyd's cycle-detection (slow/fast pointers) on the digit-square-sum sequence.
// A non-happy number always enters a cycle that does not include 1.
// Slow advances one step; fast advances two steps per iteration.
// If they meet at 1, the number is happy. If they meet at any other value, a cycle exists.
// This avoids storing the visited set that a hash-based approach would need.
// Time: O(log n) per step (digit sum computation). Space: O(1).

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

