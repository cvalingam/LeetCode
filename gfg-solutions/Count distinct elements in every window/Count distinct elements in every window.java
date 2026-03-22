import java.util.*;

class Solution {
    ArrayList<Integer> countDistinct(int arr[], int k) {
        ArrayList<Integer> al = new ArrayList<Integer>();
        int l = 0;
        int r = k - 1;

        while (r < arr.length) {
            HashSet<Integer> hs = new HashSet<Integer>();
            for (int i = l; i <= r; i++)
                hs.add(arr[i]);
            l++;
            r++;
            al.add(hs.size());
        }

        return al;
    }
}

// Version 2
class Solution1 {
    ArrayList<Integer> countDistinct(int arr[], int k) {
        ArrayList<Integer> res = new ArrayList<>();
        int i = 0, n = arr.length;
        Map<Integer, Integer> map = new HashMap<>();
        for (int j = 0; j < n; j++) {
            map.put(arr[j], map.getOrDefault(arr[j], 0) + 1);

            if (j - i + 1 == k) {
                res.add(map.size());
                if (map.containsKey(arr[i]) && map.get(arr[i]) > 1)
                    map.put(arr[i], map.get(arr[i]) - 1);
                else
                    map.remove(arr[i]);
                i++;
            }

        }

        return res;
    }
}