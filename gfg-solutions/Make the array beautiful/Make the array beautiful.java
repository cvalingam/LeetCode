
import java.util.*;

// Approach: Stack-based sign elimination. If current number has opposite sign from stack top, pop (cancel).
// Otherwise, push current number. At the end, reverse the stack to restore original order.
// Time: O(n) Space: O(n)

class Solution {

    List<Integer> makeBeautiful(int[] arr) {
        // Create a stack to store the integers
        Stack<Integer> stack = new Stack<>();

        // Iterate over the input array
        for (int num : arr) {
            // If the stack is empty, push the integer onto the stack
            if (stack.empty()) {
                stack.push(num);
            } else {
                // If the integer has a different sign than the top of the stack, pop the top element
                if ((stack.peek() >= 0 && num < 0) || (stack.peek() < 0 && num >= 0)) {
                    stack.pop();
                } else {
                    // Otherwise, push the integer onto the stack
                    stack.push(num);
                }
            }
        }

        // Create a new ArrayList to store the result
        ArrayList<Integer> result = new ArrayList<>();

        // Pop the elements from the stack and add them to the result ArrayList
        while (!stack.empty()) {
            result.add(stack.peek());
            stack.pop();
        }

        // Reverse the order of the elements in the result ArrayList
        Collections.reverse(result);

        // Return the result ArrayList
        return result;
    }
}
