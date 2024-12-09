public class Solution
{
    public bool[] IsArraySpecial(int[] nums, int[][] queries)
    {
        bool[] ans = new bool[queries.Length];
        // parityIds[i] := the id of the parity group that nums[i] belongs to
        int[] parityIds = new int[nums.Length];
        int id = 0;
        parityIds[0] = id;

        for (int i = 1; i < nums.Length; ++i)
        {
            if (nums[i] % 2 == nums[i - 1] % 2)
                ++id;
            parityIds[i] = id;
        }

        for (int i = 0; i < queries.Length; ++i)
        {
            int from = queries[i][0];
            int to = queries[i][1];
            ans[i] = parityIds[from] == parityIds[to];
        }

        return ans;
    }
}