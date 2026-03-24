namespace ATM;

public class Account
{
    public int Balance { get; private set; }

    public Account(int initialBalance)
    {
        Balance = initialBalance;
    }

    public int GetBalance()
    {
        return Balance;
    }

    public bool Withdraw(int amount)
    {


		// Validate 
		if (amount <= 0)
		return false;
		if (amount > Balance)
		return false;
        Balance -= amount;
        return true;
    }
    
    public bool Deposit(int amount)
    {
        Balance += amount;
        return true;
    }
    
}