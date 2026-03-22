import java.util.*;

class Solution {
    public static ArrayList<Integer> subsetXOR(int n) {
        ArrayList<Integer> result = new ArrayList<>();
        int X = xorTillN(n);

        if (X == n) {
            for (int i = 1; i <= n; i++)
                result.add(i);
            return result;
        }

        int k = X ^ n;
        if (k >= 1 && k <= n) {
            for (int i = 1; i <= n; i++) {
                if (i != k)
                    result.add(i);
            }
            return result;
        }

        int t = X ^ n;
        int removeA = -1, removeB = -1;

        for (int a = 1; a <= n; a++) {
            int b = a ^ t;
            if (b > a && b <= n) {
                removeA = a;
                removeB = b;
                break;
            }
        }

        for (int i = 1; i <= n; i++) {
            if (i != removeA && i != removeB)
                result.add(i);
        }

        return result;
    }

    private static int xorTillN(int n) {
        if (n % 4 == 0)
            return n;
        if (n % 4 == 1)
            return 1;
        if (n % 4 == 2)
            return n + 1;
        return 0;
    }
}
