public class Solution
{
    public int MinimumPairRemoval(int[] nums)
    {
        int ans = 0;
        List<int> numsList = nums.ToList();

        while (HasInversion(numsList))
        {
            List<int> pairSums = new List<int>();
            for (int i = 0; i < numsList.Count - 1; ++i)
                pairSums.Add(numsList[i] + numsList[i + 1]);

            int minPairSum = int.MaxValue;
            int minPairIndex = -1;
            for (int i = 0; i < pairSums.Count; ++i)
            {
                if (pairSums[i] < minPairSum)
                {
                    minPairSum = pairSums[i];
                    minPairIndex = i;
                }
            }

            numsList[minPairIndex] = minPairSum;
            numsList.RemoveAt(minPairIndex + 1);
            ++ans;
        }

        return ans;
    }

    private bool HasInversion(List<int> nums)
    {
        for (int i = 0; i < nums.Count - 1; ++i)
        {
            if (nums[i] > nums[i + 1])
                return true;
        }
        
        return false;
    }
}