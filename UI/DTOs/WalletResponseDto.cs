namespace UI.DTOs
{
    public class WalletResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }
        public string Note { get; set; } 
    }
}
