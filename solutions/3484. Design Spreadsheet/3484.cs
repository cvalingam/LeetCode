public class Spreadsheet
{

    // Dictionary to store cell values, where key is cell name (e.g., "A1") and value is the integer value
    private Dictionary<string, int> cellValues;

    public Spreadsheet(int rows)
    {
        this.cellValues = new Dictionary<string, int>();
    }

    public void SetCell(string cell, int value)
    {
        cellValues[cell] = value;
    }

    public void ResetCell(string cell)
    {
        cellValues.Remove(cell);
    }

    public int GetValue(string formula)
    {
        int sum = 0;

        // Remove the leading '=' and split by '+' to get individual terms
        string[] terms = formula.Substring(1).Split('+');

        // Process each term in the formula
        foreach (string term in terms)
        {
            // Check if the term is a number or a cell reference
            if (char.IsDigit(term[0]))
                // If it starts with a digit, parse it as a number
                sum += int.Parse(term);
            else
            {
                // Otherwise, treat it as a cell reference and get its value (default to 0 if not found)
                cellValues.TryGetValue(term, out int value);
                sum += value;
            }
        }

        return sum;
    }
}

/**
 * Your Spreadsheet object will be instantiated and called as such:
 * Spreadsheet obj = new Spreadsheet(rows);
 * obj.SetCell(cell,value);
 * obj.ResetCell(cell);
 * int param_3 = obj.GetValue(formula);
 */