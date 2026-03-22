import java.util.*;

class Solution {
    public ArrayList<Integer> farMin(int[] arr) {
        int n = arr.length;
        int[] max = new int[n];
        max[n - 1] = n - 1;
        for (int i = n - 2; i >= 0; i--) {
            if (arr[i] < arr[max[i + 1]])
                max[i] = i;
            else
                max[i] = max[i + 1];
        }
        ArrayList<Integer> ans = new ArrayList<>();
        for (int i = 0; i < n; i++)
            ans.add(binS(arr, max, arr[i], i));

        return ans;
    }

    public static int binS(int[] arr, int[] max, int val, int s) {
        int e = arr.length - 1;
        int ans = -1;
        while (s <= e) {
            int m = (s + e) / 2;

            if (arr[max[m]] < val) {
                ans = m;
                s = m + 1;
            } else
                e = m - 1;
        }
        return ans;

    }
}