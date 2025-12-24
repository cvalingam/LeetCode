public class Solution
{
    public int MinimumBoxes(int[] apple, int[] capacity)
    {
        int appleSum = apple.Sum();
        int capacitySum = 0;

        Array.Sort(capacity);

        for (int i = 0; i < capacity.Length; ++i)
        {
            capacitySum += capacity[capacity.Length - 1 - i];
            if (capacitySum >= appleSum)
                return i + 1;
        }

        return capacity.Length;
    }
}