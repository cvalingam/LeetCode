class Solution {
    public static String caseSort(String s) {
        int[] upper = new int[26];
        int[] lower = new int[26];
        for (char a : s.toCharArray()) {
            if (a >= 'a' && a <= 'z')
                lower[a - 'a']++;
            else
                upper[a - 'A']++;

        }
        int i = 0;
        int j = 0;
        StringBuilder sb = new StringBuilder();
        for (int k = 0; k < s.length(); k++) {
            char ch = s.charAt(k);
            if (ch >= 'a' && ch <= 'z') {
                while (lower[i] == 0)
                    i++;

                sb.append((char) ('a' + i));
                lower[i]--;
            } else {
                while (upper[j] == 0)
                    j++;

                sb.append((char) ('A' + j));
                upper[j]--;
            }
        }
        
        return sb.toString();
    }
}