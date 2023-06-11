using System.Net.NetworkInformation;
using System.Linq;

namespace ATM_HM46
{
    public class Atm
    {
        private List<Customer> Customers { get; set; }
        private Customer CurrentCustomer { get; set; }
        private Account CurrentAccount { get; set; }

        public Atm(List<Customer> customers)
        {
            Customers = customers;
        }

        public bool Authorize(int pin)
        {
            foreach (var customer in Customers.Where(customer => customer.CheckPin(pin)))
            {
                CurrentCustomer = customer;
                return true;
            }

            return false;
        }

        public string? GetCurrentCustomerName()
        {
            return CurrentCustomer.Name;
        }

        public List<string>? GetAccountNumbers()
        { 
            return CurrentCustomer.GetAccountNumbers();
        }

        public bool SelectAccount(string accountNumber)
        {
            var account = CurrentCustomer.GetAccount(accountNumber);

            CurrentAccount = account;
            return true;
        }

        public double GetBalance()
        {
            return CurrentAccount.Balance;
        }

        public bool Withdraw(double amount)
        {
            return CurrentAccount.Withdraw(amount);
        }
    }
}