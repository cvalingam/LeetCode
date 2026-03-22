
class Solution {
    public int findTarget(int arr[], int target) {
        int left = 0;
        int right = arr.length - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            // Check if element is at mid, mid-1 or mid+1
            if (arr[mid] == target) {
                return mid;
            }

            if (mid > 0 && arr[mid - 1] == target) {
                return mid - 1;
            }

            if (mid < arr.length - 1 && arr[mid + 1] == target) {
                return mid + 1;
            }

            // Decide which half to go into
            if (arr[mid] < target) {
                left = mid + 2; // Skip both mid and mid+1
            } else {
                right = mid - 2; // Skip both mid and mid-1
            }
        }

        return -1; // Target not found
    }
}