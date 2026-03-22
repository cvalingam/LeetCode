import java.util.*;

class Solution {
    public String longestCommonPrefix(String arr[]) {
        Arrays.sort(arr);
        int n = arr.length;
        String first = arr[0], last = arr[n - 1];

        if (first.charAt(0) != last.charAt(0))
            return "-1";

        int i = 0;
        StringBuilder sb = new StringBuilder();
        while (i < first.length() && i < last.length()) {
            if (first.charAt(i) == last.charAt(i))
                sb.append(first.charAt(i));
            else
                return sb.toString();

            i++;
        }

        return sb.toString();
    }
}