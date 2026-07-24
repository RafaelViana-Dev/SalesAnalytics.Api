namespace SalesAnalytics.Api.Models
{
    public class SalesSummaryDto
    {
        public decimal TotalRevenue { get; set; }
        public int TotalOrders { get; set; }
        public decimal AverageTicket { get; set; }

    }

    public class CategorySalesDto
    {
        public string Category { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public double Percentage { get; set; }

    }
}
