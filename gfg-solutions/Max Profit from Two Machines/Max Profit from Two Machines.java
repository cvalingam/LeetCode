
import java.util.*;

// Approach: Greedy with sorting by |a[i] - b[i]| descending.
// Tasks with the largest difference are assigned to the machine where they have the higher profit.
// When machine A has capacity and a[i] >= b[i] (or machine B is full), assign to A; otherwise assign to B.
// Sorting ensures the most impactful assignment decisions are made first.
// Time: O(n log n) Space: O(n)

class Solution {

    public int maxProfit(int x, int y, int[] a, int[] b) {
        int n = a.length;
        List<Task> tasks = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            tasks.add(new Task(a[i], b[i]));
        }

        tasks.sort((t1, t2) -> t2.diff - t1.diff);

        int profit = 0;
        int countA = 0, countB = 0;

        for (Task t : tasks) {
            if ((t.a >= t.b && countA < x) || countB >= y) {
                profit += t.a;
                countA++;
            } else {
                profit += t.b;
                countB++;
            }
        }
        return profit;
    }

    static class Task {

        int a, b, diff;

        Task(int a, int b) {
            this.a = a;
            this.b = b;
            this.diff = Math.abs(a - b);
        }
    }
}
