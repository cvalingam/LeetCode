import java.util.*;

class Solution {
    public int findSubString(String str) {
        // Step 1: Identify all unique characters in the string
        Set<Character> uniqueChars = new HashSet<>();
        for (char c : str.toCharArray())
            uniqueChars.add(c);

        int uniqueCharCount = uniqueChars.size();

        // Step 2: Sliding window technique
        Map<Character, Integer> charCount = new HashMap<>();
        int start = 0, end = 0;
        int minLength = Integer.MAX_VALUE;
        int distinctCount = 0;

        while (end < str.length()) {
            char currentChar = str.charAt(end);
            charCount.put(currentChar, charCount.getOrDefault(currentChar, 0) + 1);

            // If this character's count becomes 1, increment distinctCount
            if (charCount.get(currentChar) == 1)
                distinctCount++;

            // Try to shrink the window if all unique characters are included
            while (distinctCount == uniqueCharCount) {
                // Update the minimum length
                minLength = Math.min(minLength, end - start + 1);

                // Shrink the window from the left
                char startChar = str.charAt(start);
                charCount.put(startChar, charCount.get(startChar) - 1);

                // If the count of startChar becomes 0, decrement distinctCount
                if (charCount.get(startChar) == 0)
                    distinctCount--;

                start++;
            }

            end++;
        }

        return minLength;
    }
}