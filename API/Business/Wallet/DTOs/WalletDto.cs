namespace API.Business.Wallet.DTOs
{
    public class WalletDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }
        public string Note { get; set; }

        public BalanceChangeDto[] BalanceChanges { get; set; }
    }
}
