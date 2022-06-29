namespace DLMCapitalGroup.DTOs
{
    public class CreateCustomerDto
    {
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public decimal MonthlyIncome { get; set; }
        public decimal AverageMonthlyIncome { get; set; }
        public decimal YearlyIncome { get; set; }
        public int IncomeSources { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public decimal RequestedAmount { get; set; }
    }
}
