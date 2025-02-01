using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEasyBank_CSharp_BootCampApp;
internal class BankAccount
{
    public string Number { get; private set; }
    public string Owner { get; private set; }
    public float Balance { get; private set; }

    public BankAccount(string number, string Owner, float initialBalance)
    {
        this.Number = number;
        this.Owner = Owner;
        this.Balance = initialBalance;
    }

    public void MakeDeposit(float amount)
    {
        this.Balance += amount;
        Console.WriteLine("Einzahlung erfolgreich!");
    }

    public void MakeWithdrawl(float amount)
    {
        if (Balance >= amount)
        {
            this.Balance -= amount;
            Console.WriteLine("Auszahlung erfolgreich!");
        }
        else
        {
            Console.WriteLine("Unzureichender Saldo");
        }

    }
}
