namespace ATM_HM46
{
    public class Customer
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        private int Pin { get; set; }
        private List<Account> Accounts { get; set; }

        public Customer(string name, string surname, int pin, List<Account> accounts)
        {
            Name = name;
            Surname = surname;
            Pin = pin;
            Accounts = accounts;
        }

        public bool CheckPin(int pin)
        {
            return Pin == pin;
        }

        public List<string> GetAccountNumbers()
        {
            var accountNumbers = new List<string>();
            foreach (var account in Accounts)
            {
                accountNumbers.Add(account.AccountNumber);
            }
            return accountNumbers;
        }

        public Account? GetAccount(string accountNumber)
        {
            foreach (var account in Accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }
    }
}