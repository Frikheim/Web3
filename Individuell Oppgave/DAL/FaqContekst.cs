using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Individuell_Oppgave.DAL
{
    public class SpørsmålSvar
    {
        public int Id { get; set; }  
        public string Spørsmål { get; set; }
        public string Svar { get; set; }
        public string Kategori { get; set; }
        public int TommelOpp { get; set; } 
        public int TommelNed { get; set; }
    }
   

    public class FaqContext : DbContext
    {
            public FaqContext (DbContextOptions<FaqContext> options)
                    : base(options)
            {
                Database.EnsureCreated();
        }

        public DbSet<SpørsmålSvar> Faq { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
