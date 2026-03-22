import java.util.*;

class Solution {
    public int countBalanced(String[] arr) {
        HashMap<Integer, Integer> map = new HashMap<>();

        map.put(0, 1);

        int sum = 0;
        int ans = 0;

        for (int i = 0; i < arr.length; i++) {
            sum += countDiff(arr[i]);

            if (map.containsKey(sum))
                ans += map.get(sum);

            map.put(sum, map.getOrDefault(sum, 0) + 1);
        }

        return ans;
    }

    private boolean isVowel(char ch) {
        return "aeiuo".indexOf(ch) >= 0;
    }

    private int countDiff(String s) {
        int v = 0, c = 0;
        for (char ch : s.toCharArray()) {
            if (isVowel(ch))
                v++;
            else
                c++;
        }

        return v - c;
    }
}