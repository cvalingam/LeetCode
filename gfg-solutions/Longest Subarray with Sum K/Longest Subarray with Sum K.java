class Solution {
    public int longestSubarray(int[] arr, int k) {
        Map<Integer, Integer> list = new HashMap<>();
        list.put(0, -1);
        int max_length = 0;
        int prefix_sum = 0;

        for (int i = 0; i < arr.length; i++) {
            prefix_sum += arr[i];

            if (list.containsKey(prefix_sum - k))
                max_length = Math.max(max_length, i - list.get(prefix_sum - k));

            list.putIfAbsent(prefix_sum, i);
        }

        return max_length;
    }
}
