// Approach: Pop k elements from front and add to back (or use modular arithmetic on index).
// Time: O(k) Space: O(1)
import java.util.*;

class Solution {
    public static void rotateDeque(Deque<Integer> dq, int type, int k) {
        while (k-- > 0) {
            if (type == 1)
                dq.addFirst(dq.pollLast());
            else
                dq.addLast(dq.pollFirst());
        }
    }
}