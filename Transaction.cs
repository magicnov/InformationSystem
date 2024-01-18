namespace InformationSystem
{
    internal class Transaction
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static List<Transaction> transactions = new(FileWork.Deserialization<Transaction>(path));

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
}