// Approach: Stack-based. If after popping an operator inside brackets nothing useful remains, it's redundant.
// Time: O(n) Space: O(n)
import java.util.*;

class Solution {
    public static boolean checkRedundancy(String s) {
        Stack<Character> st = new Stack<>();

        for (char ch : s.toCharArray()) {
            if (ch == ')') {
                int opCnt = 0;
                while (!st.isEmpty()) {
                    char popped = st.pop();
                    if (popped == '(')
                        break;
                    else if (isOperator(popped))
                        opCnt++;
                }
                
                if (opCnt == 0)
                    return true;
            } else
                st.push(ch);
        }

        return false;
    }

    static boolean isOperator(char ch) {
        return ch == '+' || ch == '-' || ch == '*' || ch == '/';
    }
}
