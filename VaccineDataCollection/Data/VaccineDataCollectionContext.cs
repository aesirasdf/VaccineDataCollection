using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VaccineDataCollection.Models;

namespace VaccineDataCollection.Data
{
    public class VaccineDataCollectionContext : DbContext
    {
        public VaccineDataCollectionContext (DbContextOptions<VaccineDataCollectionContext> options)
            : base(options)
        {
        }

        public DbSet<VaccineDataCollection.Models.Vaccine> Vaccine { get; set; }

        public DbSet<VaccineDataCollection.Models.ClinicalTrial> ClinicalTrial { get; set; }
    }
}
