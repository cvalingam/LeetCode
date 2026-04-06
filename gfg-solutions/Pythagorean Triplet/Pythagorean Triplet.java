// Approach: Sort array, square all elements. For each largest element use two pointers to find a^2 + b^2 = c^2.
// Time: O(n^2) Space: O(1)
import java.util.*;

class Solution {
    boolean pythagoreanTriplet(int[] arr) {
        int n = arr.length;

        Set<Integer> set = new HashSet<>();

        for (int val : arr)
            set.add(val);

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int a = arr[i];
                int b = arr[j];
                int c = (int) Math.sqrt(a * a + b * b);

                if (c * c == a * a + b * b && set.contains(c))
                    return true;
            }
        }

        return false;
    }
}