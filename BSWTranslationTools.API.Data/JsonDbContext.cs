using BSWTranslationTools.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSWTranslationTools.API.Data
{
    public class JsonDbContext:DbContext
    {
        public JsonDbContext(DbContextOptions<JsonDbContext> options)
          : base(options)
        {

        }
        public DbSet<JsonDetails> jsonDetails { get; set; }
        public DbSet<JsonDetailsKey> jsonDetailsKey { get; set; }
        public DbSet<Audit_logs> audit_Logs { get; set; }
    }
}
