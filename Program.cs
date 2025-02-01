using System.ComponentModel.Design;

namespace MyEasyBank_CSharp_BootCampApp;

internal class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();

    static void Main(string[] args)
    {
        Console.WriteLine("Herzlich Willkommen in Ihrer EasyBank-App!");
        ShowMainMenue();
    }

    static void ShowMainMenue()
    {
        while (true)
        {
            Console.WriteLine("Was möchten Sie tun?");
            Console.WriteLine("1. Bestehendes Konto aufrufen");
            Console.WriteLine("2. Neues Konto anlegen");
            Console.WriteLine("3. EasyBank-App beenden");
            string auswahl = Console.ReadLine();
            if (auswahl == "1")
            {
                Console.WriteLine("\nBitte geben Sie Ihre Kontonummer an:");
                string number = Console.ReadLine() ?? "";

                BankAccount? account = accounts.Find(a => a.Number == number);
                if (account != null)
                {
                    ShowAccountMenue(account);
                }
                else
                {
                    Console.WriteLine("Konto nicht gefunden.");
                   
                }
            }
            else if (auswahl == "2")
            {
                CreateAccount();
            }
            else if (auswahl == "3")
            {
                Console.WriteLine("Auf Wiedersehen!");
                break;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                
            }
            Console.WriteLine();
        }
    }

    static void CreateAccount()
    {
        Console.WriteLine();
        Console.WriteLine("In Ordnung! Lassen Sie uns ein neues Konto für Sie anlegen!");
        while (true)
        {
            Console.WriteLine("Bitte geben sie Ihren Namen ein:");
            string Name = Console.ReadLine() ?? "";
            Console.WriteLine();

            if (Name != "")
            {
                string number = $"DE{100 + accounts.Count}";

                Console.WriteLine($"Guten Tag {Name}!\nWir haben ein neues Konto für Sie angelegt.\nDie Kontonummer lautet: " + number);
                Console.WriteLine("\nMöchten Sie bereits eine Einzahlung tätigen?");
                bool wantsInitialDeposit = Console.ReadLine() == "Ja";
                if (wantsInitialDeposit)
                {
                    Console.WriteLine("\nGeben Sie den Betrag ein, den Sie einzahlen möchten:");
                    float amount = float.Parse(Console.ReadLine());
                    accounts.Add(new BankAccount(number, Name, amount));
                }
                else
                {
                    accounts.Add(new BankAccount(number, Name, 0f));
                }
                break;
            }
            else
            {
                
                Console.WriteLine("Ungültige Eingabe! Möchten Sie es erneut versuchen?");
                string input = Console.ReadLine();
                if (input != "Ja")
                {
                    break;
                }
            }
        }
    }   

    static void ShowAccountMenue(BankAccount account)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"Willkommen {account.Owner}!");
            Console.WriteLine("Was möchten Sie tun?");
            Console.WriteLine("1. Kontostand abfragen");
            Console.WriteLine("2. Einzahlung tätigen");
            Console.WriteLine("3. Auszahlung tätigen");
            Console.WriteLine("4. Zurück zum Hauptmenü");
            string input = Console.ReadLine();

            Console.WriteLine();
            if (input == "1")
            {
                Console.WriteLine($"Ihr Kontostand ist: {account.Balance} Euro");
            }
            else if (input == "2")
            {
                Console.WriteLine("Geben Sie den Betrag ein, den Sie einzahlen möchten:");
                float amount = float.Parse(Console.ReadLine());
                account.MakeDeposit(amount);
            }
            else if (input == "3")
            {
                Console.WriteLine("Geben Sie den Betrag ein, den Sie abheben möchten:");
                float amount = float.Parse(Console.ReadLine());
                account.MakeWithdrawl(amount);
            }
            else if (input == "4")
            {
                Console.WriteLine($"Auf Wiedersehen {account.Owner}!");
                break;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
            }
            
        }
    }
}
