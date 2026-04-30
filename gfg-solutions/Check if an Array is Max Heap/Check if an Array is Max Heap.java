
/*
 * Check if an Array is Max Heap
 *
 * APPROACH — Linear Scan of Child-Parent Relationships
 * -----------------------------------------------------
 * For every non-root node i (index 1..n-1), its parent is at (i-1)/2.
 * A max-heap requires every child to be <= its parent.
 * Iterate i from n-1 down to 1; if arr[i] > arr[(i-1)/2], return false.
 * Iterating over children (not parents) avoids the one-child edge case
 * since we always look *up* at a guaranteed parent.
 *
 * COMPLEXITY
 * ----------
 * Time:  O(n) — single pass over all n-1 non-root nodes
 * Space: O(1) — no extra data structures
 */
class Solution {

    public boolean isMaxHeap(int[] arr) {
        for (int i = arr.length - 1; i >= 1; i--) {
            if (arr[i] > arr[(i - 1) / 2]) {
                return false;
            }
        }

        return true;
    }
}
