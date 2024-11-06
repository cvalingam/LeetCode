public class Solution
{
    public bool CanSortArray(int[] nums)
    {
        int n = nums.Length;
        int[] setCnt = new int[n];

        for (int i = 0; i < n; i++)
            setCnt[i] = setBitCount(nums[i]);

        int[] dupNums = new int[n];
        Array.Copy(nums, 0, dupNums, 0, n);
        Array.Sort(dupNums);

        for (int i = 0; i < n; i++)
        {
            int j = i;
            while (j + 1 < n && setCnt[j + 1] == setCnt[j])
                j++;

            if (j == n)
                j--;

            if (!check(nums, dupNums, i, j))
                return false;
            i = j;
        }

        return true;
    }

    private bool check(int[] nums, int[] dupNums, int i, int j)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();
        for (int k = i; k <= j; k++)
        {
            list1.Add(nums[k]);
            // Console.WriteLine("Nums value: " + nums[k]);
            list2.Add(dupNums[k]);
            // Console.WriteLine("dupNUms value: " + dupNums[k]);
        }

        list1.Sort();

        return list1.SequenceEqual(list2);
    }

    private int setBitCount(int val)
    {
        int cnt = 0;
        while (val != 0)
        {
            cnt += ((val & 1) == 1) ? 1 : 0;
            val = val >> 1;
        }

        return cnt;
    }
}