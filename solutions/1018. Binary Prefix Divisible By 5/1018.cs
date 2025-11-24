public class Solution
{
    public IList<bool> PrefixesDivBy5(int[] nums)
    {
        IList<bool> ans = new List<bool>();
        int curr = 0;

        foreach (int num in nums)
        {
            curr = (curr * 2 + num) % 5;
            ans.Add(curr % 5 == 0);
        }

        return ans;
    }
}