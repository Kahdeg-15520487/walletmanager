namespace API.DAL.Models
{
    public class Wallet
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }
        public string Note { get; set; }
        public bool IsHidden { get; set; } = false;
        public ICollection<BalanceChange> BalanceChanges { get; set; }

        public Guid UserId { get; set; }
    }
}
