namespace ATM_HM46
{
    public class Account
    {
        public string AccountNumber { get; private set; }
        public double Balance { get; private set; }

        public Account(string accountNumber, double balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public bool Withdraw(double amount)
        {
            if (amount > Balance)
            {
                return false;
            }
            else
            {
                Balance -= amount;
                return true;
            }
        }
    }
}