import java.util.*;

class Solution {
    public static ArrayList<ArrayList<Integer>> permuteDist(int[] arr) {
        ArrayList<ArrayList<Integer>> res = new ArrayList<>();
        int n = arr.length;

        ArrayList<Boolean> freq = new ArrayList<>();
        for (int i = 0; i < n; i++)
            freq.add(false);

        solve(arr, res, new ArrayList<>(), freq);
        return res;
    }

    static void solve(int[] arr,
            ArrayList<ArrayList<Integer>> res,
            ArrayList<Integer> li,
            ArrayList<Boolean> freq) {

        if (li.size() == arr.length) {
            res.add(new ArrayList<>(li));
            return;
        }

        for (int i = 0; i < arr.length; i++) {
            if (!freq.get(i)) {
                freq.set(i, true);
                li.add(arr[i]);

                solve(arr, res, li, freq);

                // backtrack
                li.remove(li.size() - 1);
                freq.set(i, false);
            }
        }
    }
};