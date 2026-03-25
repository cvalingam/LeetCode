// Approach: Frequency of remainders mod k; remainder r must pair with remainder k-r; remainder 0 must be even-count.
// Time: O(n) Space: O(k)

public class Solution
{
    public bool CanArrange(int[] arr, int k)
    {
        int[] count = new int[k];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] %= k;
            count[arr[i] < 0 ? arr[i] + k : arr[i]]++;
        }

        if (count[0] % 2 != 0)
            return false;

        for (int i = 1; i <= k / 2; i++)
        {
            if (count[i] != count[k - i])
                return false;
        }

        return true;
    }
}