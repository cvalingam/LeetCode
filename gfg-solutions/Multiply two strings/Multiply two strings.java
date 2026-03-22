class Solution {
    public String multiplyStrings(String s1, String s2) {
        if (s1.equals("0") || s2.equals("0"))
            return "0";

        boolean negative = false;

        if (s1.charAt(0) == '-') {
            negative = !negative;
            s1 = s1.substring(1);
        }
        if (s2.charAt(0) == '-') {
            negative = !negative;
            s2 = s2.substring(1);
        }

        int n = s1.length();
        int m = s2.length();
        int[] result = new int[n + m];

        for (int i = n - 1; i >= 0; i--) {
            for (int j = m - 1; j >= 0; j--) {
                int mul = (s1.charAt(i) - '0') * (s2.charAt(j) - '0');
                int sum = mul + result[i + j + 1];

                result[i + j + 1] = sum % 10;
                result[i + j] += sum / 10;
            }
        }

        StringBuilder sb = new StringBuilder();
        for (int num : result) {
            if (sb.length() != 0 || num != 0)
                sb.append(num);
        }

        if (sb.length() == 0)
            return "0";

        return negative ? "-" + sb.toString() : sb.toString();
    }
}