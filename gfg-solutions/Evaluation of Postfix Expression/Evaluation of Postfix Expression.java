class Solution {
    public int evaluate(String[] arr) {
        Deque<Integer> operands = new ArrayDeque<>();
        int num1 = 0, num2 = 0;
        for (String el : arr) {

            if (el.equals("+") || el.equals("-") || el.equals("*") || el.equals("/")) {
                num2 = operands.pop();
                num1 = operands.pop();
            }

            if (el.equals("+"))
                operands.push(num1 + num2);
            else if (el.equals("-"))
                operands.push(num1 - num2);
            else if (el.equals("*"))
                operands.push(num1 * num2);
            else if (el.equals("/"))
                operands.push(num1 / num2);
            else
                operands.push(Integer.parseInt(el));
        }

        return operands.peek();
    }
}