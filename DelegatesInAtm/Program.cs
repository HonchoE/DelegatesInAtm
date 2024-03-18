using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            ATMService atmService = new ATMService();

            if (atmService.Login())
            {
                atmService.RunATM();
            }
        }
    }
}