
import java.util.*;

// Approach: BFS over the 1000 possible values modulo 1000.
// From a value x, every arr[i] creates a directed edge to (x * arr[i]) % 1000.
// BFS guarantees the first time we reach end, we used the minimum number of multiplications.
// Time: O(1000 * arr.length) Space: O(1000)

class Solution {

    public int minSteps(int[] arr, int start, int end) {
        // Edge Case
        if (start == end) {
            return 0;
        }

        // Mod is 1000, so 1000 values at max
        int[] steps = new int[1001];
        Arrays.fill(steps, 1000000000);
        Deque<Integer> q = new ArrayDeque<>();

        steps[start] = 0;
        q.offerLast(start);

        while (!q.isEmpty()) {
            int curr = q.removeFirst();

            // Like recursion, multiplying with every element
            for (int val : arr) {
                int next = (curr * val) % 1000;

                // Same as min step in recursion, step + 1 because the step is valid or not
                if (steps[curr] + 1 < steps[next]) {
                    steps[next] = steps[curr] + 1;

                    if (next == end) {
                        return steps[next];
                    }

                    q.offerLast(next);
                }
            }
        }

        return -1;
    }
}
