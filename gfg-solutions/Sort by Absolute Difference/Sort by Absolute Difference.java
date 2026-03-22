import java.util.*;

class Solution {
    public void rearrange(int[] arr, int x) {
        TreeMap<Integer, List<Integer>> tm = new TreeMap<>();
        for (int i = 0; i < arr.length; i++) {
            int diff = Math.abs(arr[i] - x);
            if (!tm.containsKey(diff)) {
                List<Integer> li = new ArrayList<>();
                li.add(arr[i]);
                tm.put(diff, li);
            } else
                tm.get(diff).add(arr[i]);
        }
        List<Integer> ans = new ArrayList<>();
        for (Map.Entry<Integer, List<Integer>> entry : tm.entrySet())
            ans.addAll(entry.getValue());

        for (int i = 0; i < arr.length; i++)
            arr[i] = ans.get(i);

    }
}
