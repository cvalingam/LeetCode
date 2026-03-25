// Approach: Encode digit frequencies as a single integer; compare n's encoding against the encodings of all 30 powers of 2.
// Time: O(log n) Space: O(log n)

public class Solution
{
    public bool ReorderedPowerOf2(int n)
    {
        int count = Counter(n);

        for (int i = 0; i < 30; ++i)
        {
            if (Counter(1 << i) == count)
                return true;
        }

        return false;
    }

    private int Counter(int n)
    {
        int count = 0;

        while (n > 0)
        {
            count += (int)Math.Pow(10, n % 10);
            n /= 10;
        }

        return count;
    }
}