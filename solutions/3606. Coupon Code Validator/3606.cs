public class Solution
{
    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
    {
        // Store indices of valid coupons
        List<int> validIndices = new List<int>();

        // Define allowed business lines
        HashSet<string> allowedBusinessLines = new HashSet<string>
        {
            "electronics", "grocery", "pharmacy", "restaurant"
        };

        // Iterate through all coupons to find valid ones
        for (int i = 0; i < code.Length; i++)
        {
            // Check if coupon is active, business line is allowed, and code format is valid
            if (isActive[i] &&
                allowedBusinessLines.Contains(businessLine[i]) &&
                IsValidCouponCode(code[i]))
                validIndices.Add(i);
        }

        // Sort valid coupon indices by business line first, then by coupon code
        validIndices.Sort((index1, index2) =>
        {
            // Compare business lines alphabetically
            int businessLineComparison = string.Compare(businessLine[index1], businessLine[index2], StringComparison.Ordinal);
            if (businessLineComparison != 0)
                return businessLineComparison;
            // If business lines are the same, compare coupon codes alphabetically
            return string.Compare(code[index1], code[index2], StringComparison.Ordinal);
        });

        // Build result list with sorted coupon codes
        List<string> sortedCouponCodes = new List<string>();
        foreach (int index in validIndices)
            sortedCouponCodes.Add(code[index]);

        return sortedCouponCodes;
    }

    /// <summary>
    /// Checks if a coupon code contains only valid characters.
    /// Valid characters are letters, digits, and underscores.
    /// </summary>
    /// <param name="couponCode">The coupon code to validate</param>
    /// <returns>true if the code is valid, false otherwise</returns>
    private bool IsValidCouponCode(string couponCode)
    {
        // Empty codes are invalid
        if (string.IsNullOrEmpty(couponCode))
            return false;

        // Check each character in the code
        foreach (char character in couponCode)
        {
            // Code must contain only alphanumeric characters or underscores
            if (!char.IsLetterOrDigit(character) && character != '_')
                return false;
        }

        return true;
    }
}