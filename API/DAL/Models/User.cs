namespace API.DAL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IdpId { get; set; }

        public ICollection<Wallet> Wallets { get; set; }
    }
}
