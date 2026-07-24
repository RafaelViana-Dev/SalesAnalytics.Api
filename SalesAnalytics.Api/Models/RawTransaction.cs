using System.Data;

namespace SalesAnalytics.Api.Models
{
    public class RawTransaction
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Category {  get; set; } = string.Empty;
        public decimal Amount {  get; set; }
        public string Status { get; set; } = string.Empty; // "Completed", "Canceled", "Pending"
        public DateTime TransactionDate { get; set; }
    }
}
