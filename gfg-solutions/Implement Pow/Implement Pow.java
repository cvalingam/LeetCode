class Solution {
    double power(double b, int e) {
        double ans = 1.0;
        int nn = e;
        if (e < 0)
            nn = -1 * e;

        while (nn > 0) {
            if (nn % 2 == 0) {
                b = b * b;
                nn /= 2;
            } else {
                ans = ans * b;
                nn -= 1;
            }
        }

        if (e < 0)
            return (double) 1.0 / (double) ans;

        return ans;
    }
}