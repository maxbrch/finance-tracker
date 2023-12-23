using System;
public static class FinanceTracker
{
    private static int ubalance = 0;
    private static string[] history = { };

    public static void Main(string[] args)
    {
        // General menu 
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Finance Tracker\n" + "1. Add transaction\n" + "2. View balance\n" + "3. View transaction history\n" + "4. Exit");
            int command;
            int.TryParse(Console.ReadLine(), out command);

            switch (command)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Finance Tracker - Add Transaction \n 1. Income \n 2. Expense");
                    int type;
                    int.TryParse(Console.ReadLine(), out type);
                    Console.Write("Enter amount: ");
                    int amount;
                    int.TryParse(Console.ReadLine(), out amount);
                    if (type == 1)
                    {
                        Console.Write("Typing note to transaction: ");
                        string note = Console.ReadLine();
                        ubalance += amount;
                        string transaction = string.Format("{0} | +{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), amount, "Note: ", note);
                        history = history.Append(transaction);
                    }
                    else if (type == 2)
                    {
                        string note = Console.ReadLine();
                        ubalance -= amount;
                        string transaction = string.Format("{0} | -{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), amount, "Note: ", note);
                        history = history.Append(transaction);
                    }
                    Console.WriteLine("Transaction added successfully. \n Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Your balance: {0}", ubalance + "\n Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 3:
                    if (history.Length > 0)
                    {
                        Console.WriteLine("Transaction history:");
                        foreach (string transaction in history)
                        {
                            Console.WriteLine(transaction);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no transactions yet.");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid command. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // Append note to history
    public static T[] Append<T>(this T[] array, T item)
    {
        if (array == null)
        {
            return new T[] { item };
        }
        T[] result = new T[array.Length + 1];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = array[i];
        }
        result[array.Length] = item;
        return result;
    }
}
