using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PortfolioBi.Client.Db.PricingDataAnalysis.Models;

#nullable disable

namespace PortfolioBi.Client.Db.PricingDataAnalysis.Ef
{
    public partial class PricingDataAnalysisDbContext
    {

        public virtual DbSet<AvgPrice> AvgPrice { get; set; }
        public virtual DbSet<MaxPrice> MaxPrice { get; set; }
        public virtual DbSet<MinPrice> MinPrice { get; set; }
        public virtual DbSet<LocalMaxPrice> LocalMaxPrice { get; set; }
        public virtual DbSet<ReturnOnInvestment> ReturnOnInvestment { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvgPrice>(entity => entity.HasNoKey());
            modelBuilder.Entity<MaxPrice>(entity => entity.HasNoKey());
            modelBuilder.Entity<MinPrice>(entity => entity.HasNoKey());
            modelBuilder.Entity<LocalMaxPrice>(entity => entity.HasNoKey());
            modelBuilder.Entity<ReturnOnInvestment>(entity => entity.HasNoKey());


        }
    }
}
