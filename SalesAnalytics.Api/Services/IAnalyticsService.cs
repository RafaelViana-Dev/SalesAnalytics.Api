using SalesAnalytics.Api.Models;

namespace SalesAnalytics.Api.Services
{
    public interface IAnalyticsService
    {
        SalesSummaryDto GetSummary();
        List<CategorySalesDto> GetSalesByCategory();
    }
}
