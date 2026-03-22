import java.util.*;

class Solution {
    public static ArrayList<Integer> countLessEq(int a[], int b[]) {
        ArrayList<Integer> ans = new ArrayList<>();
        Arrays.sort(b);
        for (int i = 0; i < a.length; i++) {
            int num = a[i];
            int small = binarySearch(num, b);
            ans.add(small);
        }
        return ans;
    }

    private static int binarySearch(int target, int[] b) {
        int n = b.length;
        int start = 0;
        int end = n - 1;
        int ans = 0;

        while (start <= end) {

            int mid = start + (end - start) / 2;
            if (b[mid] <= target) {
                ans = Math.max(ans, mid + 1);
                start = mid + 1;
            } else
                end = mid - 1;
        }
        return ans;
    }
}