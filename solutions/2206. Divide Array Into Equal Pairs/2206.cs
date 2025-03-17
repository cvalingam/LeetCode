public class Solution
{
    public bool DivideArray(int[] nums)
    {
        int[] count = new int[501];

        foreach (var num in nums)
            ++count[num];

        return count.All(c => c % 2 == 0);
    }
}