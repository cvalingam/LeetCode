public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        HashSet<int> numsSet = new HashSet<int>(nums);
        int mn = nums.Min();
        if (mn < k)
            return -1;
        if (mn > k)
            return numsSet.Count;
        return numsSet.Count - 1;
    }
}