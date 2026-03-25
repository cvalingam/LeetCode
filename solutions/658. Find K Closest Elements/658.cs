// Approach: Binary search for the left boundary of the optimal k-element
// window; compare distances x-arr[m] vs arr[m+k]-x symmetrically.
// Time: O(log(n-k)+k) Space: O(1)

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