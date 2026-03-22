import java.util.*;

class Solution {
    public ArrayList<Integer> countBSTs(int[] arr) {
        ArrayList<Integer> ans = new ArrayList<>();

        for (int x : arr) {
            int less = countLess(arr, x);
            int more = countMore(arr, x);
            ans.add(findCatalan(less) * findCatalan(more));
        }

        return ans;
    }

    private static int mem[] = new int[30];

    private static int findCatalan(int n) {
        if (n <= 1)
            return 1;

        if (mem[n] != 0)
            return mem[n];

        int res = 0;

        for (int i = 0; i < n; i++)
            res += findCatalan(i) * findCatalan(n - i - 1);

        return mem[n] = res;
    }

    private int countLess(int arr[], int x) {
        int c = 0;
        for (int e : arr) {
            if (e < x)
                c++;
        }

        return c;
    }

    private int countMore(int arr[], int x) {
        int c = 0;
        for (int e : arr) {
            if (e > x)
                c++;
        }

        return c;
    }
}