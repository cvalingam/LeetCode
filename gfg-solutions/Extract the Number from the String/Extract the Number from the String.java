class Solution {
    long ExtractNumber(String sentence) {
        String arr[] = sentence.split(" ");
        long max = -1;
        for (String st : arr) {
            if (st.charAt(0) - '0' >= 0 && st.charAt(0) - '0' <= 9) {
                if (!st.contains("9")) {
                    long convert = Long.parseLong(st);
                    if (convert > max)
                        max = convert;
                }
            }
        }

        return max;
    }
}