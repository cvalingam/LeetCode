import java.util.*;

class Solution {
    // Function to find the majority elements in the array
    public List<Integer> findMajority(int[] nums) {
        Map<Integer, Integer> countMap = new HashMap<>();
        List<Integer> result = new ArrayList<>();
        int n = nums.length / 3;

        for (int num : nums)
            countMap.put(num, countMap.getOrDefault(num, 0) + 1);

        for (Map.Entry<Integer, Integer> entry : countMap.entrySet()) {
            if (entry.getValue() > n)
                result.add(entry.getKey());
        }

        return result;
    }
}

// Version 2
class Solution1 {
    public ArrayList<Integer> findMajority(int[] arr) {
        int tot = arr.length;
        ArrayList<Integer> ans = new ArrayList<>();
        TreeMap<Integer, Integer> mp = new TreeMap<>();

        for (int n : arr)
            mp.put(n, mp.getOrDefault(n, 0) + 1);

        for (int k : mp.keySet()) {
            if (tot / 3 < mp.get(k))
                ans.add(k);
        }

        return ans;
    }
}
