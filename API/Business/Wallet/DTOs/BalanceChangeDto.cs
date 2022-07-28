namespace API.Business.Wallet.DTOs
{
    public class BalanceChangeDto
    {
        public Guid WalletId { get; set; }
        public bool ChangeType { get; set; }
        public float Amount { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
    }
}
