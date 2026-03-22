import java.util.*;

class Solution {
    // Function to find if there is a celebrity in the party or not.
    public int celebrity(int mat[][]) {
        int n = mat.length;
        int candidate = 0;

        for (int i = 1; i < n; i++) {
            if (mat[candidate][i] == 1)
                candidate = i;
        }

        for (int i = 0; i < n; i++) {
            if (i != candidate && mat[candidate][i] == 1)
                return -1;

            if (i != candidate && mat[i][candidate] == 0)
                return -1;
        }

        return candidate;
    }
}

class Solution1 {
    public int celebrity(int mat[][]) {
        int n = mat.length;
        Stack<Integer> stack = new Stack<>();

        // Step 1: Push all people into the stack
        for (int i = 0; i < n; i++)
            stack.push(i);

        // Step 2: Eliminate non-celebrities
        while (stack.size() > 1) {
            int a = stack.pop();
            int b = stack.pop();

            if (knows(mat, a, b))
                // a knows b → a can't be celebrity
                stack.push(b);
            else
                // a doesn't know b → b can't be celebrity
                stack.push(a);
        }

        // Step 3: Verify the remaining candidate
        int candidate = stack.pop();
        for (int i = 0; i < n; i++) {
            if (i == candidate)
                continue;
            if (knows(mat, candidate, i) || !knows(mat, i, candidate))
                return -1;
        }

        return candidate;
    }

    // Helper function
    private boolean knows(int[][] mat, int i, int j) {
        return mat[i][j] == 1;
    }
}