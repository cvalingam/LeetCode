class Solution {
    public int maxLen(int[] arr) {
        int n = arr.length;
        Map<Integer, Integer> map = new HashMap<>();

        for (int i = 0; i < n; i++) {
            if (arr[i] == 0)
                arr[i] = -1;
        }

        int sum = 0;
        int max = 0;

        for (int i = 0; i < n; i++) {
            sum += arr[i];
            if (sum == 0) {
                max = i + 1;
                continue;
            }

            if (map.containsKey(sum))
                max = Math.max(max, i - map.get(sum));
            else
                map.put(sum, i);
        }

        return max;
    }
}
