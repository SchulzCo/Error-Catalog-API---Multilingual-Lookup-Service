using Microsoft.EntityFrameworkCore;
using Error_Catalog_API___Multilingual_Lookup_Service.Models;
using System.Collections.Generic;

namespace Error_Catalog_API___Multilingual_Lookup_Service.Data
{

    namespace ErrorCatalogApi.Data
    {
        public class ErrorCatalogDbContext : DbContext
        {
            public ErrorCatalogDbContext(DbContextOptions<ErrorCatalogDbContext> options)
                : base(options)
            { }

            public DbSet<ErrorCatalogEnglish> ErrorCatalog_English { get; set; }
            public DbSet<ErrorCatalogSpanish> ErrorCatalog_Spanish { get; set; }
        }
    }
}