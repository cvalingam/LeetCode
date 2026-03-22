class Solution {

    // a: input array
    // n: size of array
    // Function to find maximum circular subarray sum.
    public int circularSubarraySum(int arr[]) {
        int n = arr.length;
        int min = Integer.MAX_VALUE;
        int max = Integer.MIN_VALUE;
        int sum1 = 0, sum2 = 0, total = 0;
        for (int i = 0; i < n; i++) {
            sum1 += arr[i];
            sum2 += arr[i];
            total += arr[i];

            if (sum2 > 0)
                sum2 = 0;
            else
                min = Math.min(min, sum2);

            if (sum1 < 0)
                sum1 = 0;
            else
                max = Math.max(max, sum1);
        }

        return Math.max(max, total - min);
    }
}

// Version 2
class Solution1 {
    public int maxCircularSum(int arr[]) {
        int n = arr.length;

        // Step 1: Standard Kadane’s algorithm to find max subarray sum
        int max_kadane = kadane(arr);

        // Step 2: Total sum of the array
        int total_sum = 0;
        for (int i = 0; i < n; i++) {
            total_sum += arr[i];
            arr[i] = -arr[i]; // Invert the elements to find min subarray sum
        }

        // Step 3: Find min subarray sum using Kadane on inverted array
        int max_inverse_kadane = kadane(arr); // Actually gives -min subarray sum
        int max_circular = total_sum + max_inverse_kadane;

        // Step 4: Handle case when all numbers are negative
        if (max_circular == 0)
            return max_kadane;

        // Step 5: Return the maximum of two results
        return Math.max(max_kadane, max_circular);
    }

    // Standard Kadane’s algorithm to find max subarray sum
    private int kadane(int[] arr) {
        int max_so_far = arr[0];
        int current_max = arr[0];

        for (int i = 1; i < arr.length; i++) {
            current_max = Math.max(arr[i], current_max + arr[i]);
            max_so_far = Math.max(max_so_far, current_max);
        }

        return max_so_far;
    }
}
