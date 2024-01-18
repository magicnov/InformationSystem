namespace InformationSystem.Entities;

internal class Transaction
{
    public static readonly string Path = AppDomain.CurrentDomain.BaseDirectory;
    public static List<Transaction> Transactions = new(FileWork.Deserialization<Transaction>(Path));

    public Transaction(int id, string name, int amount, string date, bool profit)
    {
        this.id = id;
        this.name = name;
        this.amount = amount;
        this.date = date;
        this.profit = profit;
    }

    public int id { get; set; }
    public string name { get; set; }
    public int amount { get; set; }
    public string date { get; set; }
    public bool profit { get; set; }
}