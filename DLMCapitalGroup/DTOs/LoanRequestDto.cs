namespace DLMCapitalGroup.DTOs
{
    public class LoanRequestDto
    {
        public string AccountId { get; set; }
        public decimal RequestedAmount { get; set; }
        public decimal CustomerIncome { get; set; }
    }
}
