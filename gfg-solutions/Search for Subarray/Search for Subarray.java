
import java.util.*;

// Approach: KMP (Knuth-Morris-Pratt) algorithm to find all occurrences of pattern b in array a.
// Build the LPS (Longest Proper Prefix-Suffix) array to enable efficient skipping on mismatch.
// Scan through a with two pointers, using LPS to avoid redundant comparisons.
// Time: O(n + m) Space: O(m)

class Solution {

    public ArrayList<Integer> search(int[] a, int[] b) {
        int[] lsp = makeLsp(b);
        List<Integer> matched = new ArrayList<>();
        
        int i = 0; // index for text a
        int j = 0; // index for pattern b
        
        while (i < a.length) {
            if (a[i] == b[j]) {
                i++;
                j++;
                
                if (j == b.length) {
                    matched.add(i - j);
                    j = lsp[j - 1];
                }
            } else {
                if (j != 0) {
                    j = lsp[j - 1];
                } else {
                    i++;
                }
            }
        }
        
        return new ArrayList<>(matched);
    }
    
    private int[] makeLsp(int[] b) {
        int n = b.length;
        int[] dp = new int[n];
        
        for (int i = 1; i < n; i++) {
            int j = dp[i - 1];
            
            while (j > 0 && b[j] != b[i]) {
                j = dp[j - 1];
            }
            
            if (b[i] == b[j]) {
                j++;
            }
            
            dp[i] = j;
        }
        
        return dp;
    }
}