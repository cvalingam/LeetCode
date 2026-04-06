// Approach: Binary search on the minimum distance between cows.
// For a given distance, greedily check if we can place all k cows in sorted stalls.
// Time: O(n log(max-min)) Space: O(1)
class Solution {
    public static int aggressiveCows(int[] stalls, int k) {
        Arrays.sort(stalls); // Sort stall positions to enable binary search
        int low = 1; // Minimum possible distance
        int high = stalls[stalls.length - 1] - stalls[0]; // Maximum possible distance
        int result = 0;

        while (low <= high) {
            int mid = low + (high - low) / 2;
            if (canPlaceCows(stalls, k, mid)) {
                result = mid; // Update the result as we have a valid configuration
                low = mid + 1; // Try for a larger minimum distance
            } else
                high = mid - 1; // Reduce the search space
        }

        return result;
    }

    private static boolean canPlaceCows(int[] stalls, int cows, int minDis) {
        int count = 1; // Place the first cow at the first stall
        int lastPosition = stalls[0];

        for (int i = 1; i < stalls.length; i++) {
            if (stalls[i] - lastPosition >= minDis) {
                count++; // Place another cow
                lastPosition = stalls[i];
                if (count == cows)
                    return true; // If all cows are placed, return true
            }
        }

        return false;
    }
}