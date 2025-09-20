namespace exercises_poo.classes;

public class Bank
{
    public int NumAccount { get; private set; }
    public string NameUser { get; set; }
    public double MoneyActual { get; private set; }

    public Bank(int numAccount, string nameUser, double moneyActual)
    {
        NumAccount = numAccount;
        NameUser = nameUser;
        MoneyActual = moneyActual;
    }
    
    
    //method for show the money
    public double ConsultMoney()
    {
        return MoneyActual;
    }
    
    //method for transfer money to the account
    public void TransferMoney(double stock)
    {
        if (stock > 0)
        {
            MoneyActual += stock;
            Console.WriteLine($"Transfer successfully of {stock}");
        }
        else
        {
            Console.WriteLine("Transfer failed");
            Console.WriteLine("The transfer has not enough money and should be major thah zero(0)");
        }
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Account N*: {NumAccount}, Name: {NameUser}, Money: {MoneyActual}");
    }
    
    public static class BankExe
    {
        public static void exe()
        {
            Bank account = new Bank(1001, "santiago", 500);
            
            account.ShowInfo();
            account.TransferMoney(200);
            
            Console.WriteLine($"Money updated: {account.ConsultMoney():C}");
        }
    }
}