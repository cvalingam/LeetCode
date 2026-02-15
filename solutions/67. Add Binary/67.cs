public class Solution
{
    public string AddBinary(string a, string b)
    {
        StringBuilder sb = new StringBuilder();
        int carry = 0;
        int i = a.Length - 1;
        int j = b.Length - 1;

        while (i >= 0 || j >= 0 || carry == 1)
        {
            if (i >= 0)
                carry += a[i--] - '0';
            if (j >= 0)
                carry += b[j--] - '0';
            sb.Append(carry % 2);
            carry /= 2;
        }

        var charArray = sb.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}