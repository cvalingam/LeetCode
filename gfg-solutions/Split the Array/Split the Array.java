class Solution {

    public static int countgroup(int arr[]) {
        // find xor of all elements of the array
        int allXOR = 0;
        for (int x : arr)
            allXOR ^= x;

        // 2 disjoint group out of given elements exist if XOR of array is zero
        if (allXOR != 0)
            return 0;

        // No. of disjoint sets of a set = 2^(n-1)-1
        // where n = size of set or array
        int n = arr.length;
        long MOD = 1000000007;
        return (int) (((1 << (n - 1)) - 1) % MOD);
    }
}