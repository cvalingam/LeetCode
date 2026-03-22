class Solution {
    int countPairsWithDiffK(int[] arr, int k) {
        HashMap<Integer, Integer> map = new HashMap<>();
        for (Integer n : arr)
            map.put(n, map.getOrDefault(n, 0) + 1);

        int count = 0;
        for (Integer n : arr) {
            if (n + k == n) {
                count += map.get(n) * (map.get(n) - 1) / 2;
                map.put(n, 0);
            } else if (map.containsKey(n + k))
                count += map.get(n + k);

        }

        return count;
    }
}