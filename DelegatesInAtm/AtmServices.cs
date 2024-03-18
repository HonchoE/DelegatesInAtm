using System;

namespace ATM
{
    // Define a delegate type for ATM operations
    public delegate void ATMOperation(int amount, int account);

    public class ATMService
    {
        private const int CorrectPin = 200612;
        private const int MaxIncorrectAttempts = 3;

        private int balance = 10000000;
        private int incorrectAttempts = 0;
        private int account;
        private int amount;

        public bool Login()
        {
            Console.WriteLine("Enter Your Pin Number");

            do
            {
                int userPin = Convert.ToInt32(Console.ReadLine());

                if (CorrectPin == userPin)
                {
                    return true;
                }
                else
                {
                    incorrectAttempts++;
                    Console.WriteLine("Invalid PIN. Attempts remaining: " + (MaxIncorrectAttempts - incorrectAttempts));
                }

            } while (incorrectAttempts < MaxIncorrectAttempts);

            Console.WriteLine("Too many incorrect attempts. Your account is locked.");
            return false;
        }

        public void RunATM()
        {
            while (true)
            {
                Console.WriteLine("*Welcome to Ikorodu Boys ATM Service*");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Withdraw Cash");
                Console.WriteLine("3. Deposit Cash");
                Console.WriteLine("4. Send Cash");
                Console.WriteLine("5. Quit");
                Console.WriteLine("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        PerformOperation(CheckBalance, 0, 0);
                        break;
                    case 2:
                        PerformOperation(WithdrawCash, 0, 0);
                        break;
                    case 3:
                        PerformOperation(DepositCash, 0, 0);
                        break;
                    case 4:
                        PerformOperation(SendCash, 0, 0);
                        break;
                    case 5:
                        Console.WriteLine(" THANK FOR USING IKORODU BOYS ATM");
                        return;
                    default:
                        Console.WriteLine(" INVALID SELECTION, TRY AGAIN");
                        break;
                }
            }
        }

        // Method to execute the selected operation using the delegate
        private void PerformOperation(ATMOperation operation, int amount, int account)
        {
            operation.Invoke(amount, account);
        }

        // Methods representing different operations
        private void CheckBalance(int amount, int account)
        {
            Console.WriteLine(" YOUR BALANCE IN N : " + balance);
        }

        private void WithdrawCash(int amount, int account)
        {
            Console.WriteLine(" ENTER THE AMOUNT TO WITHDRAW: ");
            amount = Convert.ToInt32(Console.ReadLine());
            if (amount % 100 != 0)
            {
                Console.WriteLine(" PLEASE ENTER THE AMOUNT IN MULTIPLES OF 100");
                Console.WriteLine("THANKS FOR BANKING WITH US AT IKORODU BOYS");
            }
            else if (amount > (balance - 500))
            {
                Console.WriteLine(" INSUFFICIENT BALANCE");
                Console.WriteLine("THANKS FOR BANKING WITH US AT IKORODU BOYS");
            }
            else
            {
                balance = balance - amount;
                Console.WriteLine(" PLEASE COLLECT CASH");
                Console.WriteLine(" YOUR CURRENT BALANCE IS " + balance);
                Console.WriteLine("THANKS FOR BANKING WITH US AT IKORODU BOYS");
            }
        }

        private void DepositCash(int amount, int account)
        {
            Console.WriteLine(" ENTER THE AMOUNT TO DEPOSIT: ");
            amount = Convert.ToInt32(Console.ReadLine());
            balance = balance + amount;
            Console.WriteLine(" YOUR BALANCE IS " + balance);
            Console.WriteLine("THANKS FOR BANKING WITH US AT IKORODU BOYS");
        }

        private void SendCash(int amount, int account)
        {
            Console.WriteLine("Enter The Account To Send To");
            account = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter The Amount You Want To Send To");
            amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(amount + " HAS BEEN SENT TO THE FOLLOWING ACCOUNT " + account);
            balance = balance - amount;
            Console.WriteLine("YOUR BALANCE IS " + balance);
            Console.WriteLine("THANKS FOR BANKING WITH US AT IKORODU BOYS");
        }
    }
}