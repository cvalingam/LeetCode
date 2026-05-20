
import java.util.*;

// Approach: Hash-set single pass. For each number, check if target/number already exists in set.
// Handle zero separately. If both number and complement exist, we found a pair.
// Time: O(n) Space: O(n)

class Solution {

    public boolean isProduct(int[] arr, long target) {
        Set<Long> viewed = new HashSet<>();

        for (int num : arr) {
            if (num == 0) {
                if (target == 0) {
                    return true;
                }
            } else if (target % num == 0) {
                long needed = target / num;
                if (viewed.contains(needed)) {
                    return true;
                }
                viewed.add((long) num);
            }
        }
        
        return false;
    }
}
