public class Solution
{
    public string RobotWithString(string s)
    {
        int[] charCount = new int[26]; // Holds the count of each character in the string

        // Increment the count for each character in the string
        foreach (char ch in s)
            charCount[ch - 'a']++;

        StringBuilder answer = new StringBuilder(); // For building the final string
        Stack<char> stack = new Stack<char>(); // To keep track of characters for processing
        char minChar = 'a'; // To keep track of the smallest character that hasn't been used up

        // Iterate through all characters in the string
        foreach (char ch in s)
        {
            charCount[ch - 'a']--; // Decrease the count as we process each char

            // Update the minChar to the next available smallest character
            while (minChar < 'z' && charCount[minChar - 'a'] == 0)
                minChar++;

            stack.Push(ch); // Add current character to the stack

            // Pop characters from the stack if they are smaller or equal to the current minChar
            while (stack.Count > 0 && stack.Peek() <= minChar)
                answer.Append(stack.Pop());
        }

        return answer.ToString();
    }
}