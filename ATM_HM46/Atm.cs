using System.Net.NetworkInformation;
using System.Linq;

namespace ATM_HM46
{
    public class Atm
    {
        private readonly List<Customer> _customers;
        private Customer? _currentCustomer;
        private Account? _currentAccount;

        public Atm(List<Customer> customers)
        {
            _customers = customers;
        }

        public bool Authorize(string customerId, int pin)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return false;
            }

            if (customer.CheckPin(pin))
            {
                _currentCustomer = customer;
                return true;
            }

            return false;
        }

        public string? GetCurrentCustomerName()
        {
            if (_currentCustomer != null)
            {
                return _currentCustomer.Name;
            }

            return string.Empty;
        }

        public IEnumerable<string>? GetAccountNumbers()
        { 
            return _currentCustomer?.GetAccountNumbers();
        }

        public bool SelectAccount(string accountNumber)
        {
            var account = _currentCustomer?.GetAccount(accountNumber);

            _currentAccount = account;
            return true;
        }

        public double GetBalance()
        {
            if (CheckCurrentAccount())
            {
                return _currentAccount.Balance;
            }

            return 0;
        }

        public WithdrawResultEnum Withdraw(double amount)
        {
            if (_currentAccount == null)
            {
                return WithdrawResultEnum.CustomerAccountNotSet;
            }

            var result = _currentAccount.Withdraw(amount);

            return result ? WithdrawResultEnum.Success : WithdrawResultEnum.NotEnoughMoney;
        }

        private bool CheckCurrentAccount()
        {
            return _currentAccount != null;
        }

    }
}