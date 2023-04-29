using System;
using System.ComponentModel;

public class CardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    String phone;
    double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balacne)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balacne;
    }

    public String getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }


    public String getLastname()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOption()
        {
            Console.WriteLine("Vyberte jednu z následujících moností....");
            Console.WriteLine("1. Vložit");
            Console.WriteLine("2. Vybrat");
            Console.WriteLine("3. Ukázat zůstatek");
            Console.WriteLine("4. Odejít");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("Kolik $ chcete vložit");
            double depotit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + depotit);
            Console.WriteLine("Vložení bylo úspěšné. \n Zustatek: " + currentUser.getBalance());
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("Kolik $ chcete vybrat");
            double withdraw = Double.Parse(Console.ReadLine());
            //Zkontroluj zusatek
            if (withdraw > currentUser.getBalance())
            {
                Console.WriteLine("Nemáte dostatek peněz na účtě");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("Výběr byl úspěšný. \n Zustatek: " + currentUser.getBalance());
            }
        }   

        void balance(CardHolder currentUser)
        {
            Console.WriteLine("Zustatek: " + currentUser.getBalance());
        }   

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("123456789", 1234, "Jan", "Novak", 1000));
        cardHolders.Add(new CardHolder("987654321", 4321, "Petr", "Svoboda", 2000));
        cardHolders.Add(new CardHolder("123123123", 1111, "Jana", "Konecna", 3000));
        cardHolders.Add(new CardHolder("321321321", 2222, "Petr", "Novotny", 4000));

        Console.WriteLine("Výtejte v JustBank");
        Console.WriteLine("Zadejte číslo karty: ");
        String debitNum = "";
        CardHolder currentUser;

        while (true)
        {
            try
            {
                debitNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(x => x.cardNum == debitNum);
                if(currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatné číslo karty. Zadejte ho znovu: ");
                }
            }
            catch
            {
                Console.WriteLine("Chyba karty. Zkuzte to znovu: ");
            }
        }

        Console.WriteLine("Vložte svůj PIN: ");
        int pin = 0;
        while (true)
        {
            try
            {
                pin = int.Parse(Console.ReadLine());    
                if (currentUser.getPin() == pin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Neplatný PIN. Zkuste to znovu: ");
                }
            }
            catch
            {
                Console.WriteLine("Neplatný PIN. Zkuste to znovu: ");
            }
        }

        Console.WriteLine("Vítej " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOption();
            try
            {
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        deposit(currentUser);
                        break;
                    case 2:
                        withdraw(currentUser);
                        break;
                    case 3:
                        balance(currentUser);
                        break;
                    case 4:
                        Console.WriteLine("Děkujeme za použití JustBank");
                        break;
                    default:
                        Console.WriteLine("Neplatná volba. Zkuste to znovu");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Neplatná volba. Zkuste to znovu");
            }
        } while (option != 4);
    }
}