class Solution {
    // Function to rotate an array by d elements in counter-clockwise direction.
    static void rotateArr(int arr[], int d) {
        int n = arr.length;
        // Normalize d in case it's greater than n
        d = d % n;

        // Reverse the first part (0 to d-1)
        reverse(arr, 0, d - 1);
        // Reverse the second part (d to n-1)
        reverse(arr, d, n - 1);
        // Reverse the entire array
        reverse(arr, 0, n - 1);
    }

    private static void reverse(int[] arr, int start, int end) {
        while (start < end) {
            // Swap elements at start and end
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++;
            end--;
        }
    }
}