import java.util.*;

class Solution {
    public static int longestSubarray(int[] arr) {
        int n = arr.length;
        int maxLen = 0;

        Stack<Integer> st = new Stack<>();

        for (int i = 0; i <= n; i++) {
            int nge = (i == n ? Integer.MAX_VALUE : arr[i]);

            while (!st.isEmpty() && arr[st.peek()] < nge) {
                int curr = arr[st.pop()];
                int len = st.isEmpty() ? i : i - st.peek() - 1;

                if (len >= curr)
                    maxLen = Math.max(maxLen, len);
            }

            st.push(i);
        }

        return maxLen;

    }
}