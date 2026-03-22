import java.util.*;

class Solution {
    // Function to reverse words in a given string.
    String reverseWords(String str) {
        Stack<String> st = new Stack<>();
        StringBuilder result = new StringBuilder();

        String[] words = str.split("\\.");

        for (String word : words)
            st.push(word);

        while (!st.isEmpty()) {
            result.append(st.pop());
            if (!st.isEmpty())
                result.append(".");
        }

        return result.toString();
    }
}