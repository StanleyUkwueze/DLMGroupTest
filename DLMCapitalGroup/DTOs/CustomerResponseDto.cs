namespace DLMCapitalGroup.DTOs
{
    public class CustomerResponseDto
    {
        public string CustomerId { get; set;}
        public string CustomerName { get; set;}
        public decimal MonthlyIncome { get; set; }
        public decimal AverageMonthlyIncome { get; set; }
        public decimal YearlyIncome { get; set; }
        public int IncomeSources { get; set; }
    }
}
