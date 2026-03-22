class Solution {
    public List<List<Integer>> findTriplets(int[] arr) {
        List<List<Integer>> result = new ArrayList<>();

        int len = arr.length;

        Map<Integer, ArrayList<Integer>> map = new HashMap<>();

        for (int i = 0; i < len; i++) {
            int val = arr[i];
            if (!map.containsKey(val)) {
                map.put(val, new ArrayList<>());
            }
            map.get(val).add(i);
        }

        for (int i = 0; i < len - 2; i++) {
            for (int j = i + 1; j < len - 1; j++) {
                int target = -(arr[i] + arr[j]);
                if (map.containsKey(target)) {
                    for (int idx : map.get(target)) {
                        if (idx > j) {
                            List<Integer> al = new ArrayList<>(Arrays.asList(i, j, idx));
                            // Collections.sort(al);
                            result.add(al);
                        }
                    }
                }
            }
        }
        return result;
    }
}