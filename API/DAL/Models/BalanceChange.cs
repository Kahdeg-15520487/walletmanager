namespace API.DAL.Models
{
    public class BalanceChange
    {
        public Guid Id { get; set; }
        public Wallet Wallet { get; set; }
        public decimal Amount { get; set; }
        public bool Type { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }

        public Guid WalletId { get; set; }
    }
}
