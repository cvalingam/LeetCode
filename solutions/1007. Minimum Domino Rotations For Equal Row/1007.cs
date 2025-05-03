public class Solution
{
    public int MinDominoRotations(int[] tops, int[] bottoms)
    {
        int n = tops.Length;

        // Count occurrences for each number in tops and bottoms
        int[] countTop = new int[7];
        int[] countBottom = new int[7];
        int[] countCommon = new int[7]; // When top[i] == bottom[i]

        for (int i = 0; i < n; i++)
        {
            int t = tops[i];
            int b = bottoms[i];
            countTop[t]++;
            countBottom[b]++;
            if (t == b)
                countCommon[t]++;
        }

        int minRotations = int.MaxValue;

        // Try each possible target value from 1 to 6
        for (int candidate = 1; candidate <= 6; candidate++)
        {
            // Check if it's possible to make all values equal to candidate
            if (countTop[candidate] + countBottom[candidate] - countCommon[candidate] == n)
            {
                // Calculate rotations needed
                int rotateTop = countTop[candidate] - countCommon[candidate]; // Make all top = candidate
                int rotateBottom = countBottom[candidate] - countCommon[candidate]; // Make all bottom = candidate
                minRotations = Math.Min(minRotations, Math.Min(rotateTop, rotateBottom));
            }
        }

        return minRotations == int.MaxValue ? -1 : minRotations;
    }
}