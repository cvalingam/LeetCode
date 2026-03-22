class Solution {
    public String addBinary(String s1, String s2) {
        StringBuilder result = new StringBuilder();

        int i = s1.length() - 1;
        int j = s2.length() - 1;

        int carry = 0;

        while (i >= 0 || j >= 0 || carry == 1) {
            int a = (i >= 0) ? s1.charAt(i--) - '0' : 0;
            int b = (j >= 0) ? s2.charAt(j--) - '0' : 0;

            int sum = a + b + carry;
            result.append((sum % 2 == 0) ? '0' : '1');
            carry = sum / 2;
        }

        result.reverse();

        i = 0;
        while (result.charAt(i) == '0') {
            i++;
        }

        return result.toString().substring(i);
    }
}