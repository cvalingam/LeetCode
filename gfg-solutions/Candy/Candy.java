// Approach: Two-pass greedy. Left-to-right: give more candy if rating > left neighbor.
// Right-to-left: ensure right neighbor has more if rating > right neighbor. Sum all.
// Time: O(n) Space: O(n)
import java.util.*;

class Solution {
    public int minCandy(int arr[]) {
        int n = arr.length;

        int left[] = new int[n];
        int right[] = new int[n];

        Arrays.fill(left, 1);
        Arrays.fill(right, 1);

        for (int i = 1; i < arr.length; i++) {
            if (arr[i] > arr[i - 1])
                left[i] += left[i - 1];
        }

        for (int i = arr.length - 2; i >= 0; i--) {
            if (arr[i] > arr[i + 1])
                right[i] += right[i + 1];
        }

        int maxCandies = 0;

        for (int i = 0; i < left.length; i++)
            maxCandies += Math.max(left[i], right[i]);

        return maxCandies;
    }
}
