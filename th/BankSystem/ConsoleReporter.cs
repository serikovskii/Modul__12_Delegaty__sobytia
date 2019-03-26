using System;


namespace BankSystem
{
    public class ConsoleReporter : IReporter
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
