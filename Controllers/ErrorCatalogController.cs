using Error_Catalog_API___Multilingual_Lookup_Service.Data.ErrorCatalogApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Error_Catalog_API___Multilingual_Lookup_Service.Data;
using Error_Catalog_API___Multilingual_Lookup_Service.Models;

namespace Error_Catalog_API___Multilingual_Lookup_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorCatalogController : ControllerBase
    {
        private readonly ErrorCatalogDbContext _context;

        public ErrorCatalogController(ErrorCatalogDbContext context)
        {
            _context = context;
        }

        // GET api/ErrorCatalog?lang=en   o   GET api/ErrorCatalog?lang=es
        [HttpGet]
        public async Task<IActionResult> GetErrors([FromQuery] string lang = "en")
        {
            if (lang.ToLower() == "en")
            {
                var errorsEnglish = await _context.ErrorCatalog_English.ToListAsync();
                return Ok(errorsEnglish);
            }
            else if (lang.ToLower() == "es")
            {
                var errorsSpanish = await _context.ErrorCatalog_Spanish.ToListAsync();
                return Ok(errorsSpanish);
            }
            else
            {
                return BadRequest("Language not supported. Use 'en' for English or 'es' for Spanish.");
            }
        }
    }
}
