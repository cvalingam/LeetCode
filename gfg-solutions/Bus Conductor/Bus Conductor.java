// Approach: Simulate passenger boarding and alighting at each stop. Track current load.
// Time: O(n) Space: O(1)
import java.util.*;

class Solution {
    public int findMoves(int[] chairs, int[] passengers) {
        Arrays.sort(chairs);
        Arrays.sort(passengers);
        int result = 0;
        for (int i = 0; i < chairs.length; i++)
            result += Math.abs(chairs[i] - passengers[i]);
        
        return result;
    }
}
