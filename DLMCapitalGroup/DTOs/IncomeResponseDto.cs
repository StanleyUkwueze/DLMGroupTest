namespace DLMCapitalGroup.DTOs
{
    public class IncomeResponseDto
    {
        public decimal MonthlyIncome { get; set; }
        public decimal AverageMonthlyIncome { get; set; }
        public decimal YearlyIncome { get; set; }
        public int IncomeSources { get; set; }
    }
}
