import java.util.*;

class Solution {
    public ArrayList<Integer> largestSubset(int[] arr) {
        int n = arr.length;
        Arrays.sort(arr);

        for (int i = 0, j = arr.length - 1; i < j; i++, j--) {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        // Table to store the size of the
        // largest subset
        int[] dp = new int[n];
        Arrays.fill(dp, 1);

        // To keep track of previous elements
        int[] parent = new int[n];
        Arrays.fill(parent, -1);

        // Variables to track the maximum subset
        // size and last index
        int maxSize = 1;
        int lastIndex = 0;

        for (int i = 1; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (arr[j] % arr[i] == 0 && dp[i] < dp[j] + 1) {
                    dp[i] = dp[j] + 1;
                    parent[i] = j;
                }
            }

            // Update maxSize and lastIndex
            if (dp[i] > maxSize) {
                maxSize = dp[i];
                lastIndex = i;
            }
        }

        // Backtrack to construct the subset
        ArrayList<Integer> res = new ArrayList<>();
        for (int i = lastIndex; i >= 0; i = parent[i]) {
            res.add(arr[i]);
            if (parent[i] == -1)
                break;
        }
        
        return res;
    }
}