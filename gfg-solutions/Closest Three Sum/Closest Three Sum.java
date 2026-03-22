import java.util.*;

class Solution {
    static int threeSumClosest(int[] ar, int target) {
        Arrays.sort(ar);
        int ms = ar[0] + ar[1] + ar[ar.length - 1];

        for (int i = 0; i < ar.length - 1; i++) {
            int s = i + 1;
            int e = ar.length - 1;

            while (s < e) {

                int sum = ar[i] + ar[e] + ar[s];
                int dif = Math.abs(sum - target);

                if (dif < Math.abs(ms - target)) {

                    ms = sum;
                } else if (dif == Math.abs(ms - target) && sum > ms) {
                    ms = sum;
                }

                if (sum > target)
                    e--;
                else
                    s++;

            }

        }
        return ms;

    }
}