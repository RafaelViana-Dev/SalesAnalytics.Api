using Microsoft.AspNetCore.Mvc;
using SalesAnalytics.Api.Services;

namespace SalesAnalytics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        // Injeção de dependência do serviço de analytics
        public AnalyticsController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        /// <summary>
        /// Retorna o resumo executivo das vendas sanitizadas.
        /// </summary>
        [HttpGet("Summary")]
        public IActionResult GetSummary()
        {
            var summary = _analyticsService.GetSummary();
            return Ok(summary);
        }

        /// <summary>
        /// Retorna o faturamento e percentual por categoria de produto.
        /// </summary>
        [HttpGet("by-category")]
        public IActionResult GetSalesByCategory()
        {
            var categorySales = _analyticsService.GetSalesByCategory();
            return Ok(categorySales);

        }
    }
}
