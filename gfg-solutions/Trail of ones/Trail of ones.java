class Solution {
    public int countConsec(int n) {
        if (n == 2)
            return 1;
            
        int st = 1, fib1 = 0, fib2 = 1;
        for (int i = 3; i <= n; i++) {
            st = 2 * st + (fib2 + fib1);
            int temp = fib2;
            fib2 = fib1 + fib2;
            fib1 = temp;
        }

        return st;
    }
}
