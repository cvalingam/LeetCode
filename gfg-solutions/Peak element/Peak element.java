// Approach: Binary search. If arr[mid] < arr[mid+1], peak is on right; else peak is on left or at mid.
// Time: O(log n) Space: O(1)
class Solution {

    public int peakElement(int[] arr) {
        int low = 0;
        int high = arr.length - 1;

        while (low < high) {
            int mid = low + (high - low) / 2;

            if (arr[mid] > arr[mid + 1])
                high = mid;
            else
                low = mid + 1;
        }

        return low;
    }
}