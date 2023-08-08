namespace UI.DTOs
{
    public class BalanceChangeModel
    {
        public Guid Id { get; set; }
        public bool ChangeType { get; set; }
        public float Amount { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
    }
}
