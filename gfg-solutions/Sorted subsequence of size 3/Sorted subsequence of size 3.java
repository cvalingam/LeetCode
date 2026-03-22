import java.util.*;

class Solution {
    // Function to find three numbers such that arr[smaller[i]] < arr[i] <
    // arr[greater[i]]
    public List<Integer> find3Numbers(int[] arr) {
        int n = arr.length;

        if (n < 3) {
            return new ArrayList<>(); // No such triplet exists
        }

        // Create arrays to store the leftMin and rightMax values
        int[] leftMin = new int[n];
        int[] rightMax = new int[n];

        // Initialize leftMin array
        leftMin[0] = arr[0];
        for (int i = 1; i < n; i++) {
            leftMin[i] = Math.min(leftMin[i - 1], arr[i]);
        }

        // Initialize rightMax array
        rightMax[n - 1] = arr[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            rightMax[i] = Math.max(rightMax[i + 1], arr[i]);
        }

        // Find the triplet
        for (int i = 1; i < n - 1; i++) {
            if (arr[i] > leftMin[i - 1] && arr[i] < rightMax[i + 1]) {
                List<Integer> result = new ArrayList<>();
                result.add(leftMin[i - 1]);
                result.add(arr[i]);
                result.add(rightMax[i + 1]);
                return result;
            }
        }

        // If no triplet is found
        return new ArrayList<>();
    }
}