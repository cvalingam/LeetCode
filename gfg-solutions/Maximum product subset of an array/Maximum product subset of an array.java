import java.util.*;

class Solution {
    public long findMaxProduct(List<Integer> arr) {
        long pro = 1, min = Integer.MAX_VALUE;
        boolean hasZero = false, hasPositive = false;
        int mod = (int) 1e9 + 7;

        if (arr.size() == 1)
            return arr.get(0);

        for (int i = 0; i < arr.size(); i++) {
            int num = arr.get(i);
            if (num == 0) {
                hasZero = true;
                continue;
            } else if (num < 0) {
                if (Math.abs(num) < Math.abs(min))
                    min = num;

                pro *= num;
                pro %= mod;
            } else {
                hasPositive = true;
                pro *= num;
                pro %= mod;
            }
        }

        if (arr.size() == 2) {
            if (hasZero)
                return 0;
        }

        if (pro < 0)
            pro /= min;

        return pro % mod;
    }
}