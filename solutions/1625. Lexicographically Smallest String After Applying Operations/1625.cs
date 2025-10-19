public class Solution
{
    public string FindLexSmallestString(string s, int a, int b)
    {
        // Use BFS to explore all possible string transformations
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(s);

        // Track visited strings to avoid processing duplicates
        HashSet<string> visited = new HashSet<string>();
        visited.Add(s);

        // Initialize the answer with the original string
        string smallestString = s;
        int length = s.Length;

        // BFS to explore all reachable strings
        while (queue.Count > 0)
        {
            string currentString = queue.Dequeue();

            // Update answer if current string is lexicographically smaller
            if (string.Compare(smallestString, currentString, StringComparison.Ordinal) > 0)
                smallestString = currentString;

            // Operation 1: Add 'a' to all odd-indexed digits
            char[] charArray = currentString.ToCharArray();
            for (int i = 1; i < length; i += 2)
                // Add 'a' to digit at odd index and take modulo 10
                charArray[i] = (char)(((charArray[i] - '0' + a) % 10) + '0');
            string additionResult = new string(charArray);

            // Operation 2: Rotate string to the right by 'b' positions
            string rotationResult = currentString.Substring(length - b) + currentString.Substring(0, length - b);

            // Add both transformed strings to queue if not visited
            foreach (string transformedString in new List<string> { additionResult, rotationResult })
            {
                if (visited.Add(transformedString))
                    queue.Enqueue(transformedString);
            }
        }

        return smallestString;
    }
}