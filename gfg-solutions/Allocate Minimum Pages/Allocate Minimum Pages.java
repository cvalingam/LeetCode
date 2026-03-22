class Solution {
    public static int findPages(int[] arr, int k) {
        int n = arr.length;

        // If there are more students than books, it's not possible
        if (n < k)
            return -1;

        // Initialize low and high for binary search
        int low = 0;
        int high = 0;

        // Calculate the sum of pages and max pages in a book
        for (int i = 0; i < n; i++) {
            high += arr[i];
            low = Math.max(low, arr[i]); // Max pages in a single book
        }

        // Binary search to find the minimum possible maximum pages a student can have
        while (low < high) {
            int mid = low + (high - low) / 2;

            // Check if it's possible to allocate books with `mid` as the maximum pages
            if (isPossible(arr, k, mid))
                high = mid; // Try to find a smaller maximum
            else
                low = mid + 1; // Increase the minimum pages
        }

        // The answer will be in `low` as it's the smallest maximum possible
        return low;
    }

    // Helper function to check if it's possible to allocate books with max
    // `maxPages`
    private static boolean isPossible(int[] arr, int k, int maxPages) {
        int students = 1; // Start with the first student
        int currentSum = 0;

        for (int i = 0; i < arr.length; i++) {
            // If adding the current book exceeds maxPages, assign it to the next student
            if (currentSum + arr[i] > maxPages) {
                students++;
                currentSum = arr[i];

                // If there are more students than allowed, return false
                if (students > k)
                    return false;
            } else
                currentSum += arr[i];
        }

        return true;
    }
}

class Solution1 {
    public int findPages(int[] arr, int k) {
        int n = arr.length;
        if (k > n)
            return -1;

        int low = arr[0];

        for (int i = 1; i < arr.length; i++) {
            if (arr[i] > low)
                low = arr[i];
        }

        int high = 0;
        for (int i = 0; i < n; i++)
            high += arr[i];

        while (low <= high) {
            int mid = (low + high) / 2;
            if (countStudent(arr, mid) > k)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return low;
    }

    public int countStudent(int[] arr, int pages) {
        int n = arr.length;
        int student = 1;
        long studentPages = 0;
        for (int i = 0; i < n; i++) {
            if (studentPages + arr[i] <= pages)
                studentPages += arr[i];
            else {
                student++;
                studentPages = arr[i];
            }
        }
        return student;
    }
}