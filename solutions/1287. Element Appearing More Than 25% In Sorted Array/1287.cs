// Approach: In a sorted array the element appearing > 25% must equal its neighbor at index+n/4; check each candidate.
// Time: O(n) Space: O(1)

public class Solution
{
    public int FindSpecialInteger(int[] arr)
    {
        int n = arr.Length;
        int quarter = n / 4;

        for (int i = 0; i < n - quarter; ++i)
        {
            if (arr[i] == arr[i + quarter])
                return arr[i];
        }

        throw new ArgumentException();
    }
}