public class Solution
{
    public long PutMarbles(int[] weights, int k)
    {
        // To distribute marbles into k bags, there will be k - 1 cuts. If there's a
        // cut after weights[i], then weights[i] and weights[i + 1] will be added to
        // the cost. Also, no matter how we cut, weights[0] and weights[n - 1] will
        // be counted. So, the goal is to find the max/min k - 1 weights[i] +
        // weights[i + 1].
        int[] arr = new int[weights.Length - 1]; // weights[i] + weights[i + 1]
        long mn = 0;
        long mx = 0;

        for (int i = 0; i < arr.Length; ++i)
            arr[i] = weights[i] + weights[i + 1];

        Array.Sort(arr);

        for (int i = 0; i < k - 1; ++i)
        {
            mn += arr[i];
            mx += arr[arr.Length - 1 - i];
        }

        return mx - mn;
    }
}