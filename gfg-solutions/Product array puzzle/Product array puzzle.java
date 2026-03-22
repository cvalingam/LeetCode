import java.util.*;

class Solution {
    public static long[] productExceptSelf(int nums[]) {
        int n = nums.length;

        long[] ans = new long[n];

        long p = 1;
        int zeroCnt = 0;

        for (int num : nums) {
            if (zeroCnt > 1) {
                Arrays.fill(ans, 0);
                return ans;
            }

            if (num == 0)
                zeroCnt++;
            else
                p *= num;
        }

        if (zeroCnt > 1) {
            Arrays.fill(ans, 0);
            return ans;
        }

        if (zeroCnt == 1) {
            Arrays.fill(ans, 0);
            for (int i = 0; i < n; i++) {
                if (nums[i] == 0)
                    ans[i] = p;
            }
        } else {
            for (int i = 0; i < n; i++) {
                ans[i] = p / nums[i];
            }
        }

        return ans;
    }
}

// Another version
class Solution {
    public static int[] productExceptSelf(int nums[]) {
        int n = nums.length;

        int[] ans = new int[n];

        int p = 1;
        int zeroCnt = 0;

        for (int num : nums) {
            if (zeroCnt > 1) {
                Arrays.fill(ans, 0);
                return ans;
            }

            if (num == 0)
                zeroCnt++;
            else
                p *= num;
        }

        if (zeroCnt > 1) {
            Arrays.fill(ans, 0);
            return ans;
        }

        if (zeroCnt == 1) {
            Arrays.fill(ans, 0);
            for (int i = 0; i < n; i++) {
                if (nums[i] == 0)
                    ans[i] = p;
            }
        } else {
            for (int i = 0; i < n; i++)
                ans[i] = p / nums[i];
        }

        return ans;
    }
}
