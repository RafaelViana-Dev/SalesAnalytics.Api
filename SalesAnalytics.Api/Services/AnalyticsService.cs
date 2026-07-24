using SalesAnalytics.Api.Models;

namespace SalesAnalytics.Api.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly List<RawTransaction> _rawTransactions = new()
        {
            new RawTransaction { Id = 1, CustomerName = "Ana Silva", Category = "Eletrônicos", Amount = 2500.00m, Status = "Completed", TransactionDate = DateTime.Now.AddDays(-5) },
            new RawTransaction { Id = 2, CustomerName = "Bruno Costa", Category = "Vestuário", Amount = 150.00m, Status = "Completed", TransactionDate = DateTime.Now.AddDays(-4) },
            new RawTransaction { Id = 3, CustomerName = "Carla Dias", Category = "Eletrônicos", Amount = 4200.00m, Status = "Canceled", TransactionDate = DateTime.Now.AddDays(-3) }, // Deve ser ignorado
            new RawTransaction { Id = 4, CustomerName = "Diego Lima", Category = "Casa & Decoração", Amount = 890.00m, Status = "Completed", TransactionDate = DateTime.Now.AddDays(-2) },
            new RawTransaction { Id = 5, CustomerName = "Elena Souza", Category = "Vestuário", Amount = 320.00m, Status = "Completed", TransactionDate = DateTime.Now.AddDays(-1) },
            new RawTransaction { Id = 6, CustomerName = "Fabio Mello", Category = "Eletrônicos", Amount = 1200.00m, Status = "Completed", TransactionDate = DateTime.Now }
        };

        public SalesSummaryDto GetSummary()
        {
            // Filtra apenas vendas com status 'Completed'
            var validTransactions = _rawTransactions
                .Where(t => t.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                .ToList();

            var totalRevenue = validTransactions.Sum(t => t.Amount);
            var totalOrders = validTransactions.Count;

            // Tratamento contra divisão por zero
            var averageTicket = totalOrders > 0 ? totalRevenue / totalOrders : 0;

            return new SalesSummaryDto
            {
                TotalRevenue = totalRevenue,
                TotalOrders = totalOrders,
                AverageTicket = Math.Round(averageTicket, 2)
            };
        }

        // Regra 2: Obter Vendas Agrupadas por Categoria
        public List<CategorySalesDto> GetSalesByCategory()
        {
            var validTransactions = _rawTransactions
                .Where(t => t.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                .ToList();

            var totalRevenue = validTransactions.Sum(t => t.Amount);

            if (totalRevenue == 0) return new List<CategorySalesDto>();

            // Agrupa por Categoria e calcula os valores correspondentes
            return validTransactions
                .GroupBy(t => t.Category)
                .Select(group => new CategorySalesDto
                {
                    Category = group.Key,
                    TotalAmount = group.Sum(t => t.Amount),
                    Percentage = Math.Round((double)(group.Sum(t => t.Amount) / totalRevenue * 100), 2)
                })
                .OrderByDescending(c => c.TotalAmount)
                .ToList();
        }
    }
}
