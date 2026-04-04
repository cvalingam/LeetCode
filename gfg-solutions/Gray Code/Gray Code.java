
// Approach: For each number i in [0, 2^n), compute Gray code as i XOR (i >> 1).
// Convert to binary string and left-pad with zeros to length n.
// Time: O(2^n * n) Space: O(2^n)
import java.util.*;

class Solution {

    public ArrayList<String> graycode(int n) {
        ArrayList<String> result = new ArrayList<>();

        for (int i = 0; i < (int) Math.pow(2, n); i++) {
            int xor = i ^ (i >> 1);
            String binStr = Integer.toBinaryString(xor);
            StringBuilder sb = new StringBuilder("");
            if (binStr.length() < n) {
                for (int j = 1; j <= n - binStr.length(); j++) {
                    sb.append("0");
                }
            }
            sb.append(binStr);
            result.add(sb.toString());
        }
        
        return result;
    }
}
