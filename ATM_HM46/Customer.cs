namespace ATM_HM46
{
    public class Customer
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        private int _pin;
        private List<Account> _accounts;

        public Customer(string id, string name, string surname, int pin, List<Account> accounts)
        {
            Id  =id;
            Name = name;
            Surname = surname;
            _pin = pin;
            _accounts = accounts;
        }

        public bool CheckPin(int pin)
        {
            return _pin == pin;
        }

        public IEnumerable<string> GetAccountNumbers()
        {
            return _accounts.Select(a => a.AccountNumber);
        }

        public Account? GetAccount(string accountNumber)
        {
            return _accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
        }
    }
}