namespace API.Business.Wallet.DTOs
{
    public class BalanceChangeCreateRequestDto
    {
        public Guid WalletId { get; set; }
        public bool ChangeType { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
    }
}
