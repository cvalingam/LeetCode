// Approach: XOR all elements to get XOR of two unique numbers. Split by a set bit; XOR each group separately.
// Time: O(n) Space: O(1)
import java.util.*;

class Solution {
    public int[] singleNum(int[] nums) {
        int xxory = 0;

        for (int it : nums)
            xxory = xxory ^ it;

        int number = xxory & -xxory;
        int x = 0;
        int y = 0;
        for (int it : nums) {
            if ((it & number) != 0)
                x = x ^ it;
            else
                y = y ^ it;
        }
        List<Integer> result = new ArrayList<>();
        if (x > y) {
            result.add(y);
            result.add(x);
        } else {
            result.add(x);
            result.add(y);
        }
        
        return result.stream().mapToInt(Integer::intValue).toArray();
    }
}