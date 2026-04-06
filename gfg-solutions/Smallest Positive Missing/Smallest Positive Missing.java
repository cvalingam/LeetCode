// Approach: Cycle sort or index marking to place each positive number at its correct position.
// Time: O(n) Space: O(1)
import java.util.*;

class Solution {
    public int missingNumber(int[] arr) {
        Set<Integer> set = new HashSet<>();
        for (int i : arr)
            set.add(i);

        int ans = 1;
        while (!set.add(ans))
            ans++;

        return ans;
    }
}
