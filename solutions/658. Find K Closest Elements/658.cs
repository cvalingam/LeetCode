public class Solution
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        int l = 0;
        int r = arr.Length - k;

        while (l < r)
        {
            int m = (l + r) / 2;
            if (x - arr[m] <= arr[m + k] - x)
                r = m;
            else
                l = m + 1;
        }

        return arr.Skip(l).Take(k).ToList();
    }
}