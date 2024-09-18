public class Solution
{
    public string ReverseOnlyLetters(string s)
    {
        // Convert the input string to a character array for easier manipulation.
        char[] characters = s.ToCharArray();

        // Initialize two pointers.
        int left = 0; // The beginning of the string
        int right = s.Length - 1; // The end of the string

        // Use a while loop to iterate over the character array until the two pointers meet.
        while (left < right)
        {
            // Move the left pointer to the right as long as the current character isn't a letter.
            while (left < right && !char.IsLetter(characters[left]))
                left++;

            // Move the right pointer to the left as long as the current character isn't a letter.
            while (left < right && !char.IsLetter(characters[right]))
                right--;

            // Once both pointers are at letters, swap the characters.
            if (left < right)
            {
                char temp = characters[left];
                characters[left] = characters[right];
                characters[right] = temp;

                // Move both pointers towards the center.
                left++;
                right--;
            }
        }

        // Convert the manipulated character array back to a string and return it.
        return new string(characters);
    }
}