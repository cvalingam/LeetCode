class Solution {
    public String smallestNumber(int s, int d) {
        int result = solve(s, d, 0);

        if (result >= (int) 1e8)
            return "-1";

        return String.valueOf(result);
    }

    public int solve(int s, int d, int digit) {
        if (d == 0 && s == 0)
            return digit;

        if (d == 0 || s < 0)
            return (int) 1e8;

        int take = (int) 1e8;

        for (int i = 0; i <= 9; i++) {
            if (digit == 0 && i == 0 && d != 1)
                continue;
            take = Math.min(take, solve(s - i, d - 1, digit * 10 + i));
        }

        return take;
    }
}