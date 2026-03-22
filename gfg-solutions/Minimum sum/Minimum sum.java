import java.util.*;

class Solution {
    String minSum(int[] arr) {
        Arrays.sort(arr);

        StringBuilder s1 = new StringBuilder();
        StringBuilder s2 = new StringBuilder();
        // after sorting array take alternating numbers because of we do not want to
        // take repeating character from array......
        for (int i = 0; i < arr.length; i++) {
            if (i % 2 == 0)
                s1.append(arr[i]);
            else
                s2.append(arr[i]);
        }
        // Add these two strings (s1 and s2)
        StringBuilder sb = new StringBuilder();
        int carry = 0;
        int i = s1.length() - 1;
        int j = s2.length() - 1;

        while (i >= 0 || j >= 0 || carry > 0) {
            int digit1 = (i >= 0) ? s1.charAt(i--) - '0' : 0;
            int digit2 = (j >= 0) ? s2.charAt(j--) - '0' : 0;
            int sum = digit1 + digit2 + carry;
            sb.append(sum % 10);
            carry = sum / 10;
        }
        sb.reverse(); // after adding reverse the stringbuilder
        // remove initial zeros from stringbuilder
        while (sb.length() > 1 && sb.charAt(0) == '0')
            sb.deleteCharAt(0);
        // return the string by converting StringBuilder to String
        return sb.toString();
    }
}

class Solution1 {
    String minSum(int[] arr) {
        Arrays.sort(arr);

        StringBuilder num1 = new StringBuilder();
        StringBuilder num2 = new StringBuilder();

        for (int i = 0; i < arr.length; i++) {
            if (i % 2 == 0)
                num1.append(arr[i]);
            else
                num2.append(arr[i]);
        }

        return addStrings(num1.toString(), num2.toString());
    }

    String addStrings(String a, String b) {
        StringBuilder result = new StringBuilder();
        int i = a.length() - 1, j = b.length() - 1, carry = 0;

        while (i >= 0 || j >= 0 || carry != 0) {
            int digit1 = (i >= 0) ? a.charAt(i--) - '0' : 0;
            int digit2 = (j >= 0) ? b.charAt(j--) - '0' : 0;

            int sum = digit1 + digit2 + carry;
            result.append(sum % 10);
            carry = sum / 10;
        }

        return result.reverse().toString().replaceFirst("^0+(?!$)", "");
    }
}
