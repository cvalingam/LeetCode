public class Solution
{
    public int CountOperations(int num1, int num2)
    {
        // Initialize operation counter
        int operationCount = 0;

        // Continue operations while both numbers are non-zero
        while (num1 != 0 && num2 != 0)
        {
            // Subtract the smaller number from the larger number
            if (num1 >= num2)
                num1 -= num2;
            else
                num2 -= num1;

            // Increment the operation counter after each subtraction
            operationCount++;
        }

        // Return the total number of operations performed
        return operationCount;
    }
}