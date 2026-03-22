class Solution {
    public int startStation(int[] gas, int[] cost) {
        int n = gas.length;

        int sum = 0;
        int start = 0;
        int total = 0;

        for (int i = 0; i < 2 * n; i++) {
            int index = i % n;
            sum += gas[index] - cost[index];
            total += gas[index] - cost[index];

            if (sum < 0) {
                sum = 0;
                start = i + 1;
            }
        }

        return total >= 0 ? start % n : -1;
    }
}