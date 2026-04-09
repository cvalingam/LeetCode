// Approach: Use two pointers on the sorted arrays. Move the smaller pointer forward;
// when values match, append once (skip duplicates by checking last inserted value) and
// advance both pointers.
// Time: O(n + m) Space: O(1) extra (excluding output)

import java.util.*;

class Solution {

    ArrayList<Integer> intersection(int[] a, int[] b) {
        ArrayList<Integer> result = new ArrayList<>();

        int i = 0, j = 0;

        while (i < a.length && j < b.length) {
            if (a[i] == b[j]) {
                if (result.isEmpty() || result.get(result.size() - 1) != a[i]) {
                    result.add(a[i]);
                }
                i++;
                j++;
            } else if (a[i] < b[j]) {
                i++;
            } else {
                j++;
            }
        }

        return result;
    }
}
