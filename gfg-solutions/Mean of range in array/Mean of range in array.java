
// Approach: We can solve this efficiently by precomputing the prefix sums of the array.
// This allows us to answer each range query in O(1) time. For each query [l, r], the sum
// of the elements in the range is `sum[r] - sum[l - 1]` (handling `l=0` as a special case).
// The number of elements in the range is `r - l + 1`. The mean is the floor integer division 
// of the total sum by the count of elements.
//
// Time: O(N + Q), where N is the size of the array (to build prefix sum) and Q is the number of queries.
// Space: O(N) to store the prefix sum array.

import java.util.*;

class Solution {

    public ArrayList<Integer> findMean(int[] arr, int[][] queries) {
        ArrayList<Integer> res = new ArrayList<>();
        int sum[] = new int[arr.length];
        sum[0] = arr[0];

        for (int i = 1; i < arr.length; i++) {
            sum[i] = sum[i - 1] + arr[i];
        }

        for (int[] querie : queries) {
            int l = querie[0]; //left
            int r = querie[1]; //right
            int total = sum[r] - (l > 0 ? sum[l - 1] : 0);
            int count = (r + 1) - l;
            res.add(total / count);
        }
        return res;
    }
}
