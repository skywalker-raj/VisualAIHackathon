namespace TraditionalTests.Data_Classes
{
    public class Transaction
    {
        #region Public properties

        public string Status { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Amount { get; set; }

        #endregion

        #region Constructor

        public Transaction(string status, string date, string description, string category, string amount)
        {
            Status = status;
            Date = date;
            Description = description;
            Category = category;
            Amount = amount;
        }

        #endregion
    }
}
