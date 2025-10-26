public class Bank
{
    // Array to store account balances
    private long[] accountBalances;
    // Total number of accounts in the bank
    private int numberOfAccounts;

    /// <summary>
    /// Constructor to initialize the bank with initial account balances
    /// </summary>
    /// <param name="balance">Array of initial balances for each account</param>
    public Bank(long[] balance)
    {
        this.accountBalances = balance;
        this.numberOfAccounts = balance.Length;
    }

    /// <summary>
    /// Transfer money from one account to another
    /// </summary>
    /// <param name="account1">Source account number (1-indexed)</param>
    /// <param name="account2">Destination account number (1-indexed)</param>
    /// <param name="money">Amount of money to transfer</param>
    /// <returns>true if transfer is successful, false otherwise</returns>
    public bool Transfer(int account1, int account2, long money)
    {
        // Validate both account numbers exist and source account has sufficient balance
        if (account1 > numberOfAccounts || account2 > numberOfAccounts ||
            accountBalances[account1 - 1] < money)
            return false;

        // Deduct money from source account
        accountBalances[account1 - 1] -= money;
        // Add money to destination account
        accountBalances[account2 - 1] += money;

        return true;
    }

    /// <summary>
    /// Deposit money into an account
    /// </summary>
    /// <param name="account">Account number (1-indexed)</param>
    /// <param name="money">Amount of money to deposit</param>
    /// <returns>true if deposit is successful, false otherwise</returns>
    public bool Deposit(int account, long money)
    {
        // Validate account number exists
        if (account > numberOfAccounts)
            return false;

        // Add money to the account
        accountBalances[account - 1] += money;

        return true;
    }

    /// <summary>
    /// Withdraw money from an account
    /// </summary>
    /// <param name="account">Account number (1-indexed)</param>
    /// <param name="money">Amount of money to withdraw</param>
    /// <returns>true if withdrawal is successful, false otherwise</returns>
    public bool Withdraw(int account, long money)
    {
        // Validate account number exists and has sufficient balance
        if (account > numberOfAccounts || accountBalances[account - 1] < money)
            return false;

        // Deduct money from the account
        accountBalances[account - 1] -= money;

        return true;
    }
}

/**
 * Your Bank object will be instantiated and called as such:
 * Bank obj = new Bank(balance);
 * bool param_1 = obj.Transfer(account1,account2,money);
 * bool param_2 = obj.Deposit(account,money);
 * bool param_3 = obj.Withdraw(account,money);
 */