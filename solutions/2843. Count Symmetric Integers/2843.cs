// Approach: For even-digit numbers check if digit sum of first half equals second half.
// Time: O(n * d) Space: O(1)

public class Solution
{
    public int CountSymmetricIntegers(int low, int high)
    {
        int ans = 0;

        for (int num = low; num <= high; ++num)
        {
            if (IsSymmetricInteger(num))
                ++ans;
        }

        return ans;
    }

    private bool IsSymmetricInteger(int num)
    {
        if (num >= 10 && num <= 99)
            return num / 10 == num % 10;

        if (num >= 1000 && num <= 9999)
        {
            int left = num / 100;
            int right = num % 100;
            return left / 10 + left % 10 == right / 10 + right % 10;
        }

        return false;
    }
}