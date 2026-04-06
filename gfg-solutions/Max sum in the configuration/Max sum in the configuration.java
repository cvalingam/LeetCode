// Approach: For rotation by k: sum(k) = sum(k-1) + totalSum - n*arr[n-k]. Use prefix sum to compute efficiently.
// Time: O(n) Space: O(1)
class Solution {
    int maxSum(int[] arr) {
        int sum = 0;
        for (int i = 0; i < arr.length; i++)
            sum += (arr[i] * i);

        for (int i = 1; i < arr.length; i++)
            sum = Math.max(sum, rot(arr, i));

        return sum;
    }

    int rot(int arr[], int idx) {

        int idx2 = arr.length - idx;
        int sum = 0;
        for (int i = 0; i < arr.length; i++) {
            if (idx2 == arr.length)
                idx2 = 0;

            sum += arr[i] * idx2;
            idx2++;
        }
        
        return sum;

    }
}