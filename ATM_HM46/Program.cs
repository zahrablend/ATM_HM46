/*
Create console program which implements functionality of Atm.
Solution has to be created using OOP. 
It should be possible to authorize against Atm (Enter pin code), 
it should be possible to choose one of the customers accounts, 
and then peak a balance or take out some amount of money. 
If it is impossible to take out such amount of money there should be an error message. 
Think about encapsulation.
 */

namespace ATM_HM46
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var account1 = new Account("LT123123", 1000);
            var account2 = new Account("LV456456", 250);
            var account3 = new Account("LV789789", 3000);

            var customer1 = new Customer("Zahra", "Zvirzdinaite", 1111, new List<Account> { account1 });

            var customer2 = new Customer("Gusts", "Linkevics", 2222, new List<Account> { account2, account3 });

            var atm = new Atm(new List<Customer> { customer1, customer2 });

            while (true)
            {
                Console.WriteLine("Enter pin: ");
                int pin = Convert.ToInt32(Console.ReadLine());
                if (atm.Authorize(pin))
                {
                    Console.WriteLine("Authorization successful. Welcome, " + atm.GetCurrentCustomerName());
                }
                else
                {
                    Console.WriteLine("Error: Invalid pin");
                    continue;
                }

                Console.WriteLine("Select account: ");
                var accountNumbers = atm.GetAccountNumbers();
                for (int i = 0; i < accountNumbers.Count; i++)
                {
                    Console.WriteLine(i + ": " + accountNumbers[i]);
                }

                if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= accountNumbers.Count)
                {
                    Console.WriteLine("Error: Invalid account selection");
                    continue;
                }

                string selectedAccountNumber = accountNumbers[index];
                if (atm.SelectAccount(selectedAccountNumber))
                {
                    Console.WriteLine("Account selected: " + selectedAccountNumber);
                }

                double? balance = atm.GetBalance();
                if (balance.HasValue)
                {
                    Console.WriteLine("Balance: " + balance.Value);
                }

                Console.WriteLine("Enter amount to withdraw: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                if (atm.Withdraw(amount))
                {
                    balance = atm.GetBalance();
                    if (balance.HasValue)
                    {
                        Console.WriteLine("Withdrawal successful. New balance: " + balance.Value);
                    }
                }
                else
                {
                    Console.WriteLine("Error: Insufficient funds");
                }

                Console.WriteLine("Press X to exit or S to select another operation");
                string input = Console.ReadLine();
                if (input.ToUpper() == "X")
                {
                    break;
                }
            }
        }
    }
}