class Solution {
    int search(int[] arr, int key) {
        int low = 0, high = arr.length - 1;

        while (low < high) {
            int mid = (low + high) / 2;
            if (arr[mid] > arr[high]) {
                if (arr[mid] < key || key <= arr[high])
                    low = mid + 1;
                else
                    high = mid;
            } else {
                if (arr[mid] < key && key <= arr[high])
                    low = mid + 1;
                else
                    high = mid;
            }
        }

        if (low == high && key != arr[low])
            return -1;

        return low;
    }
}