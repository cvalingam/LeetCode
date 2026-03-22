import java.util.*;

class Solution {
    public int substrCount(String s, int k) {
        char[] arr = s.toCharArray();
        int count = 0;
        for (int i = 0; i <= arr.length - k; i++) {
            Set<Character> set = new HashSet<>();

            for (int j = i; j < i + k; j++)
                set.add(arr[j]);
                
            if (set.size() == k - 1)
                count++;
        }
        return count;
    }
}