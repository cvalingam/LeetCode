class Solution {
    public String printString(String s, char ch, int count) {
        StringBuilder result = new StringBuilder();
        int flag = 0;

        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (c == ch && flag == 0) {
                count--;
                if (count <= 0)
                    flag = 1;
            } else if (flag == 1)
                result.append(c);
        }

        return result.toString();
    }
}