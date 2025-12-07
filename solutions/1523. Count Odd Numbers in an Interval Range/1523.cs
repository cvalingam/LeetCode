public class Solution
{
    public int CountOdds(int low, int high)
    {
        // Count odd numbers in range [low, high] inclusive
        // 
        // The formula works by counting odd numbers from 0 to high,
        // then subtracting odd numbers from 0 to (low - 1)
        //
        // For any number n:
        // - If n is even, there are n/2 odd numbers in [1, n]
        // - If n is odd, there are (n+1)/2 odd numbers in [1, n]
        // 
        // (high + 1) >> 1 gives us count of odds in [0, high]
        // low >> 1 gives us count of odds in [0, low - 1]

        int oddsUpToHigh = (high + 1) >> 1;  // Right shift by 1 is equivalent to divide by 2
        int oddsBeforeLow = low >> 1;        // Count of odd numbers before low

        return oddsUpToHigh - oddsBeforeLow;
    }
}