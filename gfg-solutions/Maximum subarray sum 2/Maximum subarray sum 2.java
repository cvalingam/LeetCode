import java.util.*;

class Solution {
    public int maxSubarrSum(int[] arr, int a, int b) {
        int n = arr.length;
        long[] pref = new long[n + 1];
        for (int i = 0; i < n; i++)
            pref[i + 1] = pref[i] + arr[i];

        // We need min pref[t] for t in [j - b, j - a]
        // Use a deque to store candidate t indices with increasing pref[]
        ArrayDeque<Integer> dq = new ArrayDeque<>();

        long best = Long.MIN_VALUE;

        for (int j = 1; j <= n; j++) {
            // Add new candidate t = j - a into the deque
            int tAdd = j - a;
            if (tAdd >= 0) {
                // Maintain monotonicity: keep pref[t] increasing in deque
                while (!dq.isEmpty() && pref[dq.peekLast()] >= pref[tAdd])
                    dq.pollLast();

                dq.addLast(tAdd);
            }

            // Remove indices that are out of window: t < j - b
            int outIndex = j - b - 1;
            while (!dq.isEmpty() && dq.peekFirst() <= outIndex)
                dq.pollFirst();

            if (!dq.isEmpty()) {
                long candidate = pref[j] - pref[dq.peekFirst()];
                if (candidate > best)
                    best = candidate;
            }
        }

        // If best remains very negative due to constraints, handle (though with valid
        // inputs there is always at least one subarray)
        return (int) best;
    }
}