class Solution {
    public static int countSetBits(int n) {
        if (n == 0)
            return 0;

        // WHAT THE HELL ARE THESE LINES DOING ?

        // 17 -> nearest pow(2) which is < 17 -> 16
        // if u write binary from 15 to 1, u will find each position having (15+1)/2 ->
        // 8 set bits
        // so for _ _ _ _, each having 8 set bits -> total set bits from 1-15 => 8 * 4
        // => 32

        int p = Integer.highestOneBit(n); // largest power of 2 <= n // in this case => 16
        int x = Integer.numberOfTrailingZeros(p); // gives exponent // in this case => 4

        int bitsTill2x = x * (p >> 1); // 4 * (16 >> 1) => 4 * (8) = 32

        // so what all remains is to count for 17, 16
        // their contribution => 17 - 16 + 1 (2 set bits, basically => 10001 & 10000,
        // the 1s at leftmost are 2)
        int msbBits = n - p + 1;

        return bitsTill2x + msbBits + countSetBits(n - p);
    }
}