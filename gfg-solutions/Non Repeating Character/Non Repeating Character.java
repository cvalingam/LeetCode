class Solution {
    // Function to find the first non-repeating character in a string.
    static char nonRepeatingChar(String s) {
        Map<Character, Integer> m = new HashMap();
        int n = s.length();

        for (int i = 0; i < n; i++) {
            char ch = s.charAt(i);
            m.put(ch, m.getOrDefault(ch, 0) + 1);
        }

        for (int i = 0; i < n; i++) {
            char ch = s.charAt(i);
            
            if (m.get(ch) == 1)
                return ch;
        }
        return '$';
    }
}
