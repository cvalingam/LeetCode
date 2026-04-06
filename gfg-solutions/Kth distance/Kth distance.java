// Approach: Traverse linked list, storing positions. Find pairs with exactly k distance apart.
// Time: O(n) Space: O(n)
import java.util.*;

class Solution {
    public boolean checkDuplicatesWithinK(int[] arr, int k) {
        HashMap<Integer, Integer> hs = new HashMap<Integer, Integer>();

        for (int i = 0; i < arr.length; i++) {
            int val = hs.getOrDefault(arr[i], -1);

            if (val != -1 && i - val <= k)
                return true;

            hs.put(arr[i], i);
        }

        return false;
    }
}