
class Solution {

    public int minSteps(int m, int n, int d) {
        if (d > Math.max(m, n)) {
            return -1;
        }
        if (d % gcd(m, n) != 0) {
            return -1;
        }
        return Math.min(helper(m, n, d), helper(n, m, d));
    }

    int gcd(int a, int b) {
        if (b == 0) {
            return a;
        }
        return b == 0 ? a : gcd(b, a % b);
    }

    int helper(int full, int half, int d) {

        int bot1 = full, bot2 = 0, step = 1;
        while (bot1 != d && bot2 != d) {
            if (bot1 == 0) {
                bot1 = full;
                step++;
            }
            int po = Math.min(bot1, half - bot2);
            bot2 += po;
            bot1 -= po;
            step++;
            if (bot1 == d || bot2 == d) {
                break;
            }
            if (bot1 == 0) {
                bot1 = full;
                step++;
            }
            if (bot2 == half) {
                bot2 = 0;
                step++;
            }

        }
        return step;
    }
}
