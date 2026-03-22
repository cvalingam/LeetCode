import java.util.*;

class Solution {
    public static ArrayList<Integer> findClosestPair(int arr1[], int arr2[], int x) {
        int n = arr1.length, m = arr2.length;
        int i = 0, j = m - 1;
        int diff = Integer.MAX_VALUE;
        ArrayList<Integer> result = new ArrayList<>(2);

        while (i < n && j >= 0) {
            int sum = arr1[i] + arr2[j];
            int currDiff = Math.abs(sum - x);

            if (currDiff < diff) {
                diff = currDiff;
                result.add(0, arr1[i]);
                result.add(1, arr2[j]);
            }

            // Move pointers
            if (sum > x)
                j--;
            else 
                i++;
        }

        return result;
    }
}