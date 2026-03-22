class Solution {
    public String largestSwap(String s) {
        char maxVal = '0';
        int valIdx = -1;
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (c >= maxVal) {
                maxVal = c;
                valIdx = i;
            }
        }

        StringBuilder result = new StringBuilder(s);

        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (i != valIdx && maxVal != c) {
                char d = result.charAt(i);
                result.setCharAt(i, maxVal);
                result.setCharAt(valIdx, d);
                break;
            }
        }

        return result.toString().compareTo(s) >= 0 ? result.toString() : s;
    }
}

// Version 2
class Solution1 {
    public String largestSwap(String s) {
        char[] c = s.toCharArray();

        char maxDigit = 0;
        int maxIdx = -1, l = -1, r = -1;

        for (int i = c.length - 1; i >= 0; i--) {
            if (c[i] > maxDigit) {
                maxDigit = c[i];
                maxIdx = i;
                continue;
            }
            if (c[i] < maxDigit) {
                l = i;
                r = maxIdx;
            }
        }

        if (l == -1)
            return s;

        char t = c[l];
        c[l] = c[r];
        c[r] = t;

        return new String(c);
    }
}