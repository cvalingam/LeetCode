public class Solution
{
    public int FindSmallestInteger(int[] nums, int value)
    {
        Dictionary<int, int> count = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            int key = (num % value + value) % value;
            if (count.ContainsKey(key))
                count[key]++;
            else
                count[key] = 1;
        }

        for (int i = 0; i < nums.Length; ++i)
        {
            if (!count.ContainsKey(i % value) || count[i % value] == 0)
                return i;
            count[i % value]--;
        }

        return nums.Length;
    }
}