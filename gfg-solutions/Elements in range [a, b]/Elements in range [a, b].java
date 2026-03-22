import java.util.*;

class Solution {
    public ArrayList<Integer> cntInRange(int[] arr, int[][] queries) {
        Arrays.sort(arr);
        ArrayList<Integer> result = new ArrayList<>();
        for (int i = 0; i < queries.length; i++) {
            int s = queries[i][0];
            int e = queries[i][1];
            result.add(bisectRight(arr, e) - bisectLeft(arr, s));
        }
        
        return result;
    }

    private int bisectLeft(int[] arr, int target) {
        int low = 0, high = arr.length;
        while (low < high) {
            int mid = (low + high) / 2;
            if (arr[mid] < target)
                low = mid + 1;
            else
                high = mid;
        }

        return low;
    }

    private int bisectRight(int[] arr, int target) {
        int low = 0, high = arr.length;
        while (low < high) {
            int mid = (low + high) / 2;
            if (arr[mid] <= target)
                low = mid + 1;
            else
                high = mid;
        }

        return low;
    }
}
