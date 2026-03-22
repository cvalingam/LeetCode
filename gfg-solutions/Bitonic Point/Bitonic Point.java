class Solution {
    public int findMaximum(int[] arr) {
        int n = arr.length;
        int left = 0, right = n - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            // Check if mid is the bitonic point
            if (mid > 0 && mid < n - 1) {
                if (arr[mid] > arr[mid - 1] && arr[mid] > arr[mid + 1])
                    return arr[mid];
                else if (arr[mid] < arr[mid + 1]) // Move right (increasing part)
                    left = mid + 1;
                else // Move left (decreasing part)
                    right = mid - 1;
            } else {
                // Edge case: peak at boundaries
                if (mid == 0)
                    return Math.max(arr[mid], arr[mid + 1]);
                if (mid == n - 1)
                    return Math.max(arr[mid], arr[mid - 1]);
            }
        }

        // According to the question, exactly one bitonic point exists, so this won't be
        // reached.
        return -1;
    }
}